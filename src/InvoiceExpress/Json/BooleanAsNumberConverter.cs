using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoiceExpress;

/// <summary />
public class BooleanAsNumberConverter : JsonConverter<bool>
{
    /// <summary />
    public override bool Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        if ( reader.TokenType != JsonTokenType.Number )
            throw new InvalidOperationException( $"Expected 'Number' when converting to bool, received '{ reader.TokenType }'" );

        var v = reader.GetInt32();

        if ( v < 0 )
            throw new InvalidOperationException( $"Negative value '{ v }' was not expected when converting to bool" );

        if ( v == 0 )
            return false;

        return true;
    }


    /// <summary />
    public override void Write( Utf8JsonWriter writer, bool value, JsonSerializerOptions options )
    {
        writer.WriteNumberValue( value ? 1 : 0 );
    }
}
