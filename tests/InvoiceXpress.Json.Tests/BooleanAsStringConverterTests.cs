using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace InvoiceXpress.Json.Tests;

/// <summary />
public class BooleanAsStringConverterTests
{
    /// <summary />
    [Fact]
    public void FalseIsZero()
    {
        var v = new Class1() { Value = false };

        var json = JsonSerializer.Serialize( v );

        Assert.Equal( "{\"Value\":\"0\"}", json );
    }

    /// <summary />
    [Fact]
    public void TrueIsOne()
    {
        var v = new Class1() { Value = true };

        var json = JsonSerializer.Serialize( v );

        Assert.Equal( "{\"Value\":\"1\"}", json );
    }

    /// <summary />
    [Fact]
    public void NullIsNull()
    {
        var v = new Class2() { Value = null };

        var json = JsonSerializer.Serialize( v );

        Assert.Equal( "{\"Value\":null}", json );
    }

    /// <summary />
    [Fact]
    public void NullableFalseIsZero()
    {
        var v = new Class2() { Value = false };

        var json = JsonSerializer.Serialize( v );

        Assert.Equal( "{\"Value\":\"0\"}", json );
    }

    /// <summary />
    [Fact]
    public void NullableTrueIsOne()
    {
        var v = new Class2() { Value = true };

        var json = JsonSerializer.Serialize( v );

        Assert.Equal( "{\"Value\":\"1\"}", json );
    }


    /// <summary />
    [Theory]
    [InlineData( "{\"Value\":\"0\"}", false )]
    [InlineData( "{\"Value\":\"1\"}", true )]
    public void Parse( string json, bool v )
    {
        var obj = JsonSerializer.Deserialize<Class1>( json );

        Assert.NotNull( obj );
        Assert.Equal( v, obj!.Value );
    }


    /// <summary />
    [Theory]
    [InlineData( "{}", null )]
    [InlineData( "{\"Value\":null}", null )]
    [InlineData( "{\"Value\":\"0\"}", false )]
    [InlineData( "{\"Value\":\"1\"}", true )]
    public void NullableParse( string json, bool? v )
    {
        var obj = JsonSerializer.Deserialize<Class2>( json );

        Assert.NotNull( obj );
        Assert.Equal( v, obj!.Value );
    }


    /// <summary />
    public class Class1
    {
        /// <summary />
        [JsonConverter( typeof( BooleanAsStringConverter ) )]
        public bool Value { get; set; }
    }


    /// <summary />
    public class Class2
    {
        /// <summary />
        [JsonConverter( typeof( BooleanAsStringConverter ) )]
        public bool? Value { get; set; }
    }
}
