using InvoiceXpress.Payloads;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Json;

/// <summary />
public class EstimatePayloadConverter : JsonConverter<EstimatePayload>
{
    /// <summary />
    public override EstimatePayload? Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        throw new NotImplementedException();
    }


    /// <summary />
    public override void Write( Utf8JsonWriter writer, EstimatePayload value, JsonSerializerOptions options )
    {
    }
}
