using InvoiceXpress.Payloads;
using InvoiceXpress.Rest;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Json;

/// <summary />
public class InvoiceStateChangePayloadConverter : JsonConverter<InvoiceStateChangePayload>
{
    /// <summary />
    public override InvoiceStateChangePayload? Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        throw new NotImplementedException();
    }


    /// <summary />
    public override void Write( Utf8JsonWriter writer, InvoiceStateChangePayload value, JsonSerializerOptions options )
    {
        var elementName = InvoiceEntity.ToElementName( value.InvoiceType );

        writer.WriteStartObject();
        writer.WritePropertyName( elementName );
        JsonSerializer.Serialize( writer, value.Change, options );
        writer.WriteEndObject();
    }
}
