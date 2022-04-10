using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Json;

/// <summary />
public class BooleanAsNumberConverter : JsonConverter<bool>
{
    /// <summary />
    public override bool Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        if ( reader.TokenType != JsonTokenType.Number )
            throw new InvalidOperationException( $"Expected 'Number' when converting to bool, received '{ reader.TokenType }'" );

        var v = reader.GetInt32();

        if ( v == 0 )
            return false;

        if ( v == 1 )
            return true;

        throw new JsonException( $"Unexpected value '{ v }' when converting to bool" );
    }


    /// <summary />
    public override void Write( Utf8JsonWriter writer, bool value, JsonSerializerOptions options )
    {
        writer.WriteNumberValue( value ? 1 : 0 );
    }
}
