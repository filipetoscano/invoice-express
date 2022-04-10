using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace InvoiceXpress.Json.Tests;

/// <summary />
public class CountryCodeAsNameConverterTests
{
    /// <summary />
    [Theory]
    [InlineData( "{\"Value\":\"Portugal\"}", "PT" )]
    [InlineData( "{\"Value\":\"Italy\"}", "IT" )]
    [InlineData( "{\"Value\":\"UK\"}", "GB" )]
    public void ToJson( string json, string v )
    {
        var obj = new Class1 { Value = v };
        var str = JsonSerializer.Serialize<Class1>( obj );

        Assert.NotNull( obj );
        Assert.Equal( json, str );
    }


    /// <summary />
    [Theory]
    [InlineData( "{\"Value\":\"Portugal\"}", "PT" )]
    [InlineData( "{\"Value\":\"Italy\"}", "IT" )]
    [InlineData( "{\"Value\":\"UK\"}", "GB" )]
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
        [JsonConverter( typeof( CountryCodeAsNameConverter ) )]
        public string Value { get; set; } = default!;
    }
}
