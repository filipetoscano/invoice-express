using InvoiceXpress.Payloads;
using InvoiceXpress.Rest;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Json;

/// <summary />
public class EstimateDataPayloadConverter : JsonConverter<EstimateDataPayload>
{
    /// <summary />
    public override EstimateDataPayload? Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        throw new NotImplementedException();
    }


    /// <summary />
    public override void Write( Utf8JsonWriter writer, EstimateDataPayload value, JsonSerializerOptions options )
    {
        var propName = EstimateEntity.ToPropertyName( value.Estimate.Type );

        writer.WriteStartObject();
        writer.WritePropertyName( propName );
        JsonSerializer.Serialize( writer, value.Estimate, options );
        writer.WriteEndObject();
    }
}
