using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace InvoiceXpress.Json.Tests;

/// <summary />
public class CurrencyCodeAsNameConverterTests
{
    /// <summary />
    [Theory]
    [InlineData( "{\"Value\":\"Euro\"}", "EUR" )]
    public void ToJson( string json, string v )
    {
        var obj = new Class1 { Value = v };
        var str = JsonSerializer.Serialize<Class1>( obj );

        Assert.NotNull( obj );
        Assert.Equal( json, str );
    }


    /// <summary />
    [Theory]
    [InlineData( "{\"Value\":\"Euro\"}", "EUR" )]
    public void FromJson( string json, string v )
    {
        var obj = JsonSerializer.Deserialize<Class1>( json );

        Assert.NotNull( obj );
        Assert.Equal( v, obj!.Value );
    }


    /// <summary />
    public class Class1
    {
        /// <summary />
        [JsonConverter( typeof( CurrencyCodeAsNameConverter ) )]
        public string Value { get; set; } = default!;
    }
}
