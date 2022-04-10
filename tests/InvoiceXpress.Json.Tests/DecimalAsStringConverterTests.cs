using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace InvoiceXpress.Json.Tests;

/// <summary />
public class DecimalAsStringConverterTests
{
    /// <summary />
    [Theory]
    [InlineData( "{\"Value\":\"0\"}", 0.0 )]
    [InlineData( "{\"Value\":\"1\"}", 1.0 )]
    [InlineData( "{\"Value\":\"1.23\"}", 1.23 )]
    [InlineData( "{\"Value\":\"1000\"}", 1000 )]
    public void ToJson( string json, decimal v )
    {
        var obj = new Class1 { Value = v };
        var str = JsonSerializer.Serialize<Class1>( obj );

        Assert.NotNull( str );
        Assert.Equal( json, str );
    }


    /// <summary />
    [Theory]
    [InlineData( "{\"Value\":null}", null )]
    [InlineData( "{\"Value\":\"0\"}", 0.0 )]
    [InlineData( "{\"Value\":\"1\"}", 1.0 )]
    [InlineData( "{\"Value\":\"1.23\"}", 1.23 )]
    [InlineData( "{\"Value\":\"1000\"}", 1000 )]
    public void NullableToJson( string json, double? v )
    {
        var obj = new Class2 { Value = (decimal?) v };
        var str = JsonSerializer.Serialize<Class2>( obj );

        Assert.NotNull( str );
        Assert.Equal( json, str );
    }


    /// <summary />
    [Theory]
    [InlineData( "{\"Value\":\"0\"}", 0.0 )]
    [InlineData( "{\"Value\":\"1\"}", 1.0 )]
    [InlineData( "{\"Value\":\"1.23\"}", 1.23 )]
    [InlineData( "{\"Value\":\"1000\"}", 1000 )]
    public void FromJson( string json, decimal v )
    {
        var obj = JsonSerializer.Deserialize<Class1>( json );

        Assert.NotNull( obj );
        Assert.Equal( v, obj!.Value );
    }


    /// <summary />
    [Theory]
    [InlineData( "{}", null )]
    [InlineData( "{\"Value\":\"0\"}", 0.0 )]
    [InlineData( "{\"Value\":\"1\"}", 1.0 )]
    [InlineData( "{\"Value\":\"1.23\"}", 1.23 )]
    [InlineData( "{\"Value\":\"1000\"}", 1000 )]
    public void NullableFromJson( string json, double? v )
    {
        decimal? dv = (decimal?) v;
        var obj = JsonSerializer.Deserialize<Class2>( json );

        Assert.NotNull( obj );
        Assert.Equal( dv, obj!.Value );
    }


    /// <summary />
    public class Class1
    {
        /// <summary />
        [JsonConverter( typeof( DecimalAsStringConverter ) )]
        public decimal Value { get; set; }
    }


    /// <summary />
    public class Class2
    {
        /// <summary />
        [JsonConverter( typeof( DecimalAsStringConverter ) )]
        public decimal? Value { get; set; }
    }
}
