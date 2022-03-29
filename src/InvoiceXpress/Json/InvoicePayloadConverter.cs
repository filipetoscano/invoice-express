using InvoiceXpress.Payloads;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Json;

/// <summary />
public class InvoicePayloadConverter : JsonConverter<InvoicePayload>
{
    /// <summary />
    public override InvoicePayload? Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        throw new NotImplementedException();
    }


    /// <summary />
    public override void Write( Utf8JsonWriter writer, InvoicePayload value, JsonSerializerOptions options )
    {
    }
}
