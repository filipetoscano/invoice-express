using InvoiceXpress.Payloads;
using InvoiceXpress.Rest;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Json;

/// <summary />
public class GuideDataPayloadConverter : JsonConverter<GuideDataPayload>
{
    /// <summary />
    public override GuideDataPayload? Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        throw new NotImplementedException();
    }


    /// <summary />
    public override void Write( Utf8JsonWriter writer, GuideDataPayload value, JsonSerializerOptions options )
    {
        var elementName = GuideEntity.ToElementName( value.Guide.Type );

        writer.WriteStartObject();
        writer.WritePropertyName( elementName );
        JsonSerializer.Serialize( writer, value.Guide, options );
        writer.WriteEndObject();
    }
}
