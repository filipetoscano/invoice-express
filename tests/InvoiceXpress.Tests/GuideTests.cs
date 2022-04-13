using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace InvoiceXpress.Tests;

/// <summary />
public class GuideTests
{
    private readonly InvoiceXpressClient _client;
    private readonly ScenarioConfig _config;


    /// <summary />
    public GuideTests( InvoiceXpressClient client, ScenarioConfig config )
    {
        _client = client;
        _config = config;
    }


    /// <summary />
    [Fact]
    public async Task List()
    {
        var res = await _client.GuideListAsync( new GuideSearch(), 1 );

        Assert.NotNull( res );
        Assert.True( res.IsSuccessful );
        Assert.NotNull( res.Result );
    }


    /// <summary />
    [Fact]
    public async Task Scenario()
    {
        var today = DateOnly.FromDateTime( DateTime.UtcNow );

        var data = new GuideData()
        {
            Type = GuideType.DeliveryNote,
            Date = today,
            Reference = "reference",
            Remarks = "remarks",
            Client = new ClientRef()
            {
                Code = "XS001",
                Name = "Client #1",
            },
            Items = new List<DocumentItemRef>(),
            LoadedOn = today,
            VehicleLicensePlate = "AA-00-BB",
            AddressFrom = new Address()
            {
                AddressLines = "Rua A",
                PostalCode = "1100-111",
                City = "City",
                Country = "PT",
            },
            AddressTo = new Address()
            {
                AddressLines = "Rua B",
                PostalCode = "2200-222",
                City = "City",
                Country = "PT",
            },
        };

        data.Items.Add( new DocumentItemRef()
        {
            Code = "XPTO001",
            Description = "Description 1",
            UnitPrice = 100.0m,
            Quantity = 1,
            DiscountPercentage = 0.0m,
            VatRate = new VatRateRef() { Code = "IVA22" },
        } );

        data.Items.Add( new DocumentItemRef()
        {
            Code = "XPTO002",
            Description = "Description 2",
            UnitPrice = 50.0m,
            Quantity = 2,
            DiscountPercentage = 0.0m,
            VatRate = new VatRateRef() { Code = "IVA22" },
        } );


        /*
         * #1. Create
         */
        var create = await _client.GuideCreateAsync( data );

        Assert.NotNull( create );
        Assert.True( create.IsSuccessful );
        Assert.NotNull( create.Result );
        Assert.Equal( data.Type, create.Result!.Type );

        var guide = new GuideKey( data.Type, create.Result!.Id );


        /*
         * #2. Update
         */
        data.Id = guide.Id;

        var update = await _client.GuideUpdateAsync( data );

        Assert.NotNull( update );
        Assert.True( update.IsSuccessful );


        /*
         * #3. Get
         */
        var get = await _client.GuideGetAsync( guide );

        Assert.NotNull( get );
        Assert.True( get.IsSuccessful );


        /*
         * #4. Finalize
         */
        var finalize = await _client.GuideStateChangeAsync( guide, new GuideStateChange()
        {
            Action = GuideAction.Finalize,
            Message = "Finalize",
        } );

        Assert.NotNull( finalize );
        Assert.True( finalize.IsSuccessful );


        /*
         * #5. Send by email
         */
        var email = await _client.GuideSendByEmailAsync( guide, new EmailMessage()
        {
            To = _config.EmailTo,
            Subject = "UT",
            Body = nameof( GuideTests ) + " / " + nameof( Scenario ),
        } );

        Assert.NotNull( email );
        Assert.True( email.IsSuccessful );


        /*
         * #6. PDF
         */
        var pdf = await _client.GuidePdfGenerateAsync( guide );

        Assert.NotNull( pdf );
        Assert.True( pdf.IsSuccessful );
        Assert.NotNull( pdf.Result );


        /*
         * #7. QR code
         */
        var qr = await _client.GuideQrCodeImageAsync( guide );

        Assert.NotNull( qr );
        Assert.True( qr.IsSuccessful );
        Assert.NotNull( qr.Result );
    }
}
