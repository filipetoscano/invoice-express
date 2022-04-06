using InvoiceXpress.Payloads;
using InvoiceXpress.Rest;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Json;

/// <summary />
public class GuideStateChangePayloadConverter : JsonConverter<GuideStateChangePayload>
{
    /// <summary />
    public override GuideStateChangePayload? Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        throw new NotImplementedException();
    }


    /// <summary />
    public override void Write( Utf8JsonWriter writer, GuideStateChangePayload value, JsonSerializerOptions options )
    {
        var propName = GuideEntity.ToPropertyName( value.GuideType );

        writer.WriteStartObject();
        writer.WritePropertyName( propName );
        JsonSerializer.Serialize( writer, value.Change, options );
        writer.WriteEndObject();
    }
}
