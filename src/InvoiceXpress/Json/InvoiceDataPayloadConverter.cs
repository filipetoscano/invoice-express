using InvoiceXpress.Payloads;
using InvoiceXpress.Rest;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Json;

/// <summary />
public class InvoiceDataPayloadConverter : JsonConverter<InvoiceDataPayload>
{
    /// <summary />
    public override InvoiceDataPayload? Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        throw new NotImplementedException();
    }


    /// <summary />
    public override void Write( Utf8JsonWriter writer, InvoiceDataPayload value, JsonSerializerOptions options )
    {
        var elementName = InvoiceEntity.ToElementName( value.Invoice.Type );

        writer.WriteStartObject();
        writer.WritePropertyName( elementName );
        JsonSerializer.Serialize( writer, value.Invoice, options );
        writer.WriteEndObject();
    }
}
