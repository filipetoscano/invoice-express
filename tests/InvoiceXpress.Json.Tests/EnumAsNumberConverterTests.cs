using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace InvoiceXpress.Json.Tests;

/// <summary />
public class EnumAsNumberConverterTests
{
    /// <summary />
    [Theory]
    [InlineData( Enum1.One, 1 )]
    [InlineData( Enum1.Two, 2 )]
    [InlineData( Enum1.Three, 3 )]
    public void ToInt( Enum1 e, int i )
    {
        var v = new Class1() { Value = e };

        var json = JsonSerializer.Serialize( v );

        var exp = "{\"Value\":" + i + "}";
        Assert.Equal( exp, json );
    }

    /// <summary />
    [Theory]
    [InlineData( Enum1.One, 1 )]
    [InlineData( Enum1.Two, 2 )]
    [InlineData( Enum1.Three, 3 )]
    public void FromInt( Enum1 e, int i )
    {
        var json = "{\"Value\":" + i + "}";

        var obj = JsonSerializer.Deserialize<Class1>( json );

        Assert.NotNull( obj );
        Assert.Equal( e, obj!.Value );
    }

    /// <summary />
    [Theory]
    [InlineData( null, 0 )]
    [InlineData( Enum1.One, 1 )]
    [InlineData( Enum1.Two, 2 )]
    [InlineData( Enum1.Three, 3 )]
    public void NullableToInt( Enum1? e, int i )
    {
        var v = new Class2() { Value = e };

        var json = JsonSerializer.Serialize( v );

        var exp = "{\"Value\":" + ( e != null ? i : "null" ) + "}";
        Assert.Equal( exp, json );
    }

    /// <summary />
    [Theory]
    [InlineData( null, 0 )]
    [InlineData( Enum1.One, 1 )]
    [InlineData( Enum1.Two, 2 )]
    [InlineData( Enum1.Three, 3 )]
    public void NullableFromInt( Enum1? e, int i )
    {
        var json = "{\"Value\":" + ( e != null ? i : "null" ) + "}";

        var obj = JsonSerializer.Deserialize<Class2>( json );

        Assert.NotNull( obj );
        Assert.Equal( e, obj!.Value );
    }


    /// <summary />
    public class Class1
    {
        /// <summary />
        public Enum1 Value { get; set; }
    }


    /// <summary />
    public class Class2
    {
        /// <summary />
        public Enum1? Value { get; set; }
    }


    /// <summary />
    [JsonConverter( typeof( EnumAsNumberConverter ) )]
    public enum Enum1
    {
        One = 1,
        Two = 2,
        Three = 3,
    }
}
