using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace InvoiceXpress.Tests;

/// <summary />
public class EstimateTests
{
    private readonly InvoiceXpressClient _client;
    private readonly ScenarioConfig _config;


    /// <summary />
    public EstimateTests( InvoiceXpressClient client, ScenarioConfig config )
    {
        _client = client;
        _config = config;
    }


    /// <summary />
    [Fact]
    public async Task List()
    {
        var res = await _client.EstimateListAsync( new EstimateSearch(), 1 );

        Assert.NotNull( res );
        Assert.True( res.IsSuccessful );
        Assert.NotNull( res.Result );
    }


    /// <summary />
    [Fact]
    public async Task Scenario()
    {
        var today = DateOnly.FromDateTime( DateTime.UtcNow );

        var data = new EstimateData()
        {
            Type = EstimateType.Quote,
            Date = today,
            ValidUntil = today.AddDays( 15 ),
            Reference = "reference",
            Remarks = "remarks",
            Client = new ClientRef()
            {
                Code = "XS001",
                Name = "Client #1",
            },
            Items = new List<DocumentItemRef>(),
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
        var create = await _client.EstimateCreateAsync( data );

        Assert.NotNull( create );
        Assert.True( create.IsSuccessful );
        Assert.NotNull( create.Result );
        Assert.Equal( data.Type, create.Result!.Type );

        var est = new EstimateKey( data.Type, create.Result!.Id );


        /*
         * #2. Update
         */
        data.Id = est.Id;

        var update = await _client.EstimateUpdateAsync( data );

        Assert.NotNull( update );
        Assert.True( update.IsSuccessful );


        /*
         * #3. Get
         */
        var get = await _client.EstimateGetAsync( est );

        Assert.NotNull( get );
        Assert.True( get.IsSuccessful );


        /*
         * #4. Finalize
         */
        var finalize = await _client.EstimateStateChangeAsync( est, new EstimateStateChange()
        {
            Action = EstimateAction.Finalize,
            Message = "Finalize",
        } );

        Assert.NotNull( finalize );
        Assert.True( finalize.IsSuccessful );


        /*
         * #5. Send by email
         */
        var email = await _client.EstimateSendByEmailAsync( est, new EmailMessage()
        {
            To = _config.EmailTo,
            Subject = "UT",
            Body = nameof( EstimateTests ) + " / " + nameof( Scenario ),
        } );

        Assert.NotNull( email );
        Assert.True( email.IsSuccessful );


        /*
         * #6. PDF
         */
        var pdf = await _client.EstimatePdfGenerateAsync( est );

        Assert.NotNull( pdf );
        Assert.True( pdf.IsSuccessful );

        if ( pdf.StatusCode == HttpStatusCode.OK )
            Assert.NotNull( pdf.Result );
        else
            Assert.Null( pdf.Result );


        /*
         * #7. Accept
         */
        var accept = await _client.EstimateStateChangeAsync( est, new EstimateStateChange()
        {
            Action = EstimateAction.Accept,
            Message = "Accept",
        } );

        Assert.NotNull( accept );
        Assert.True( accept.IsSuccessful );
    }
}
