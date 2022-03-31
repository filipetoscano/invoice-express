using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Json;

/// <summary />
public class PhoneAsNumberConverter : JsonConverter<string>
{
    /// <summary />
    public override string Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        if ( reader.TokenType != JsonTokenType.Number )
            throw new InvalidOperationException( $"Expected 'Number' when converting to phone number, received '{ reader.TokenType }'" );

        var v = reader.GetInt32();

        if ( v < 0 )
            throw new InvalidOperationException( $"Negative value '{ v }' was not expected when converting to bool" );

        return v.ToString();
    }


    /// <summary />
    public override void Write( Utf8JsonWriter writer, string value, JsonSerializerOptions options )
    {
        var v = int.Parse( value );

        writer.WriteNumberValue( v );
    }
}
