using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace InvoiceXpress.Tests;

/// <summary />
public class InvoiceTests
{
    private readonly InvoiceXpressClient _client;
    private readonly ScenarioConfig _config;


    /// <summary />
    public InvoiceTests( InvoiceXpressClient client, ScenarioConfig config )
    {
        _client = client;
        _config = config;
    }


    /// <summary />
    [Fact]
    public async Task List()
    {
        var res = await _client.InvoiceListAsync( new InvoiceSearch(), 1 );

        Assert.NotNull( res );
        Assert.True( res.IsSuccessful );
        Assert.NotNull( res.Result );
    }


    /// <summary />
    [Fact]
    public async Task Scenario()
    {
        var today = DateOnly.FromDateTime( DateTime.UtcNow );

        var data = new InvoiceData()
        {
            Type = InvoiceType.Invoice,
            Date = today,
            DueDate = today.AddDays( 15 ),
            Reference = "reference",
            Remarks = "remarks",
            Client = new ClientRef()
            {
                Code = "XS001",
                Name = "Client #1",
            },
            Items = new List<DocumentItemData>(),
        };

        data.Items.Add( new DocumentItemData()
        {
            Code = "XPTO001",
            Description = "Description 1",
            UnitPrice = 100.0m,
            Quantity = 1,
            DiscountPercentage = 0.0m,
            VatRate = new VatRateRef() { Code = "IVA22" },
        } );

        data.Items.Add( new DocumentItemData()
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
        var create = await _client.InvoiceCreateAsync( data );

        Assert.NotNull( create );
        Assert.True( create.IsSuccessful );
        Assert.NotNull( create.Result );
        Assert.Equal( data.Type, create.Result!.Type );

        var inv = new InvoiceKey( data.Type, create.Result!.Id );


        /*
         * #2. Update
         */
        data.Id = inv.Id;

        var update = await _client.InvoiceUpdateAsync( data );

        Assert.NotNull( update );
        Assert.True( update.IsSuccessful );


        /*
         * #3. Get
         */
        var get = await _client.InvoiceGetAsync( inv );

        Assert.NotNull( get );
        Assert.True( get.IsSuccessful );


        /*
         * #4. Finalize
         */
        var finalize = await _client.InvoiceStateChangeAsync( inv, new InvoiceStateChange()
        {
            Action = InvoiceAction.Finalize,
            Message = "Finalize",
        } );

        Assert.NotNull( finalize );
        Assert.True( finalize.IsSuccessful );


        /*
         * #5. Send by email
         */
        var email = await _client.InvoiceSendByEmailAsync( inv, new EmailMessage()
        {
            To = _config.EmailTo,
            Subject = "UT",
            Body = nameof( InvoiceTests ) + " / " + nameof( Scenario ),
        } );

        Assert.NotNull( email );
        Assert.True( email.IsSuccessful );


        /*
         * #6. PDF
         */
        var pdf = await _client.InvoicePdfGenerateAsync( inv );

        Assert.NotNull( pdf );
        Assert.True( pdf.IsSuccessful );

        if ( pdf.StatusCode == HttpStatusCode.OK )
            Assert.NotNull( pdf.Result );
        else
            Assert.Null( pdf.Result );


        /*
         * #7. QR code
         */
        var qr = await _client.InvoiceQrCodeImageAsync( inv );

        Assert.NotNull( qr );
        Assert.True( qr.IsSuccessful );
        Assert.NotNull( qr.Result );


        /*
         * #8. Pay
         */
        var pay = await _client.InvoicePaymentAsync( inv, new InvoicePayment()
        {
            Amount = get.Result!.TotalAmount,
            PaymentMethod = PaymentMethod.Cash,
            Date = today,
        } );

        Assert.NotNull( pay );
        Assert.True( pay.IsSuccessful );
        Assert.NotNull( pay.Result );
    }
}
