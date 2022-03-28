using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace InvoiceExpress.Json.Tests;

/// <summary />
public class EnumConverterTests
{
    /// <summary />
    [Theory]
    [InlineData( Enum1.One, "uno" )]
    [InlineData( Enum1.Two, "duo" )]
    [InlineData( Enum1.Three, "tre" )]
    public void ToInt( Enum1 e, string s )
    {
        var v = new Class1() { Value = e };

        var json = JsonSerializer.Serialize( v );

        var exp = "{\"Value\":\"" + s + "\"}";
        Assert.Equal( exp, json );
    }

    /// <summary />
    [Theory]
    [InlineData( Enum1.One, "uno" )]
    [InlineData( Enum1.Two, "duo" )]
    [InlineData( Enum1.Three, "tre" )]
    public void FromInt( Enum1 e, string s )
    {
        var json = "{\"Value\":\"" + s + "\"}";

        var obj = JsonSerializer.Deserialize<Class1>( json );

        Assert.NotNull( obj );
        Assert.Equal( e, obj!.Value );
    }
    
    
    /// <summary />
    [Theory]
    [InlineData( Enum2.One, "uno" )]
    [InlineData( Enum2.Two, "duo" )]
    [InlineData( Enum2.Three, "Three" )]
    public void MixedEnum_ToInt( Enum2 e, string s )
    {
        var v = new Class2() { Value = e };

        var json = JsonSerializer.Serialize( v );

        var exp = "{\"Value\":\"" + s + "\"}";
        Assert.Equal( exp, json );
    }

    /// <summary />
    [Theory]
    [InlineData( Enum2.One, "uno" )]
    [InlineData( Enum2.Two, "duo" )]
    [InlineData( Enum2.Three, "Three" )]
    public void MixedEnum_FromInt( Enum2 e, string s )
    {
        var json = "{\"Value\":\"" + s + "\"}";

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
        public Enum2 Value { get; set; }
    }


    /// <summary />
    [JsonConverter( typeof( EnumConverter ) )]
    public enum Enum1
    {
        /// <summary />
        [EnumMember( Value = "uno" )]
        One = 1,

        /// <summary />
        [EnumMember( Value = "duo" )]
        Two = 2,

        /// <summary />
        [EnumMember( Value = "tre" )]
        Three = 3,
    }


    /// <summary />
    [JsonConverter( typeof( EnumConverter ) )]
    public enum Enum2
    {
        /// <summary />
        [EnumMember( Value = "uno" )]
        One = 1,

        /// <summary />
        [EnumMember( Value = "duo" )]
        Two = 2,

        /// <summary />
        Three = 3,
    }
}
