using InvoiceXpress.Payloads;
using System;
using System.Text.Json;
using Xunit;

namespace InvoiceXpress.Json.Tests;

/// <summary />
public class EstimatePayloadConverterTests
{
    /// <summary />
    [Theory]
    [InlineData( EstimateType.Quote, "quote" )]
    [InlineData( EstimateType.Proforma, "proforma" )]
    [InlineData( EstimateType.FeeNote, "fees_note" )]
    public void ToJson( EstimateType type, string elemName )
    {
        var src = new EstimatePayload();
        src.Estimate = new Estimate();
        src.Estimate.Type = type;
        src.Estimate.Date = new DateOnly( 2020, 12, 5 );

        var json = JsonSerializer.Serialize( src );

        Assert.NotNull( json );
        Assert.StartsWith( "{\"" + elemName + "\":", json );
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
            },
        };

        string json = JsonSerializer.Serialize( obj );
        EstimatePayload? ep = JsonSerializer.Deserialize<EstimatePayload>( json );

        Assert.NotNull( ep );
        Assert.NotNull( ep!.Estimate );
        Assert.Equal( EstimateType.Quote, ep.Estimate.Type );
    }


    /// <summary />
    [Theory]
    [InlineData( EstimateType.Quote )]
    [InlineData( EstimateType.Proforma )]
    [InlineData( EstimateType.FeeNote )]
    public void Roundtrip( EstimateType type )
    {
        var src = new EstimatePayload();
        src.Estimate = new Estimate();
        src.Estimate.Type = type;

        var json = JsonSerializer.Serialize( src );
        var tgt = JsonSerializer.Deserialize<EstimatePayload>( json );

        Assert.NotNull( tgt );
        Assert.Equal( src.Estimate.Type, tgt!.Estimate.Type );
    }
}
