using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Json;

/// <summary />
public class NumberAsVaryConverter : JsonConverter<int>
{
    /// <summary />
    public override int Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        if ( reader.TokenType == JsonTokenType.Number )
            return reader.GetInt32();

        if ( reader.TokenType == JsonTokenType.String )
        {
            var str = reader.GetString()!;

            return int.Parse( str );
        }

        throw new JsonException( $"Expected either Number or String when deserializing" );
    }


    /// <summary />
    public override void Write( Utf8JsonWriter writer, int value, JsonSerializerOptions options )
    {
        throw new NotImplementedException();
    }
}
