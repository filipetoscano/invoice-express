using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace InvoiceXpress.Json.Tests;

/// <summary />
public class NonIsoDateConverterTests
{
    /// <summary />
    [Theory]
    [InlineData( 2020, 1, 1, "01/01/2020" )]
    [InlineData( 2022, 12, 31, "31/12/2022" )]
    [InlineData( 2100, 6, 6, "06/06/2100" )]
    public void ToJson( int yy, int MM, int dd, string str )
    {
        var obj = new Class1() { Value = new DateOnly( yy, MM, dd ) };

        var json = JsonSerializer.Serialize( obj );

        Assert.Equal( "{\"Value\":\"" + str + "\"}", json );
    }


    /// <summary />
    [Theory]
    [InlineData( 2020, 1, 1, "01/01/2020" )]
    [InlineData( 2022, 12, 31, "31/12/2022" )]
    [InlineData( 2100, 6, 6, "06/06/2100" )]
    public void FromJson( int yy, int MM, int dd, string str )
    {
        var json = "{\"Value\":\"" + str + "\"}";

        var obj = JsonSerializer.Deserialize<Class1>( json );

        Assert.NotNull( obj );
        Assert.Equal( yy, obj!.Value.Year );
        Assert.Equal( MM, obj!.Value.Month );
        Assert.Equal( dd, obj!.Value.Day );
    }


    /// <summary />
    [Fact]
    public void NullableTo()
    {
        var obj = new Class2() { Value = null };

        var json = JsonSerializer.Serialize( obj );

        Assert.Equal( "{\"Value\":null}", json );
    }


    /// <summary />
    [Fact]
    public void NullableFrom()
    {
        var json = "{\"Value\":null}";
        var obj = JsonSerializer.Deserialize<Class2>( json );

        Assert.NotNull( obj );
        Assert.Null( obj!.Value );
    }


    /// <summary />
    [Theory]
    [InlineData( 2020, 1, 1, "01/01/2020" )]
    [InlineData( 2022, 12, 31, "31/12/2022" )]
    [InlineData( 2100, 6, 6, "06/06/2100" )]
    public void NullableToJson( int yy, int MM, int dd, string str )
    {
        var obj = new Class2() { Value = new DateOnly( yy, MM, dd ) };

        var json = JsonSerializer.Serialize( obj );

        Assert.Equal( "{\"Value\":\"" + str + "\"}", json );
    }


    /// <summary />
    [Theory]
    [InlineData( 2020, 1, 1, "01/01/2020" )]
    [InlineData( 2022, 12, 31, "31/12/2022" )]
    [InlineData( 2100, 6, 6, "06/06/2100" )]
    public void NullableFromJson( int yy, int MM, int dd, string str )
    {
        var json = "{\"Value\":\"" + str + "\"}";

        var obj = JsonSerializer.Deserialize<Class2>( json );

        Assert.NotNull( obj );
        Assert.True( obj!.Value.HasValue );
        Assert.Equal( yy, obj!.Value!.Value.Year );
        Assert.Equal( MM, obj!.Value!.Value.Month );
        Assert.Equal( dd, obj!.Value!.Value.Day );
    }


    /// <summary />
    public class Class1
    {
        /// <summary />
        [JsonConverter( typeof( NonIsoDateConverter ) )]
        public DateOnly Value { get; set; }
    }


    /// <summary />
    public class Class2
    {
        /// <summary />
        [JsonConverter( typeof( NonIsoDateConverter ) )]
        public DateOnly? Value { get; set; }
    }
}
