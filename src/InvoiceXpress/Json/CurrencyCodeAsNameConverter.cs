using InvoiceXpress.Map;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Json;

/// <summary />
public class CurrencyCodeAsNameConverter : JsonConverter<string>
{
    /// <summary />
    public override string Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        if ( reader.TokenType != JsonTokenType.String )
            throw new JsonException( "Expected string" );

        var name = reader.GetString()!;
        var cur = IXCurrency.Map.SingleOrDefault( x => x.Name == name );

        if ( cur == null )
            throw new JsonException( $"Currency { name } is not supported" );

        return cur.Code;
    }


    /// <summary />
    public override void Write( Utf8JsonWriter writer, string value, JsonSerializerOptions options )
    {
        var cur = IXCurrency.Map.SingleOrDefault( x => x.Code == value );

        if ( cur == null )
            throw new JsonException( $"Currency { value } is not supported" );

        writer.WriteStringValue( cur.Name );
    }
}
