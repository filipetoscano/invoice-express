using InvoiceXpress.Payloads;
using System;
using System.Text.Json;
using Xunit;

namespace InvoiceXpress.Json.Tests;

/// <summary />
public class EstimatePayloadConverterTests
{
    /// <summary />
    [Fact]
    public void ToJson()
    {
        var x = new EstimatePayload();
        x.Estimate = new Estimate();
        x.Estimate.Type = EstimateType.Quote;
        x.Estimate.Date = new DateOnly( 2020, 12, 5 );

        var json = JsonSerializer.Serialize( x );

        Assert.NotNull( json );
    }


    /// <summary />
    [Fact]
    public void FromJson()
    {
        dynamic obj = new
        {
            quote = new
            {
                type = "Quote",
                date = "05/10/2022",
                due_date = "10/10/2022",
            },
        };

        string json = JsonSerializer.Serialize( obj );
        EstimatePayload? ep = JsonSerializer.Deserialize<EstimatePayload>( json );

        Assert.NotNull( ep );
        Assert.NotNull( ep!.Estimate );
        Assert.Equal( EstimateType.Quote, ep.Estimate.Type );
    }
}
