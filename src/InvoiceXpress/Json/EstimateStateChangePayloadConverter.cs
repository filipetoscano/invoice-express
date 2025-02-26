﻿using InvoiceXpress.Payloads;
using InvoiceXpress.Rest;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Json;

/// <summary />
public class EstimateStateChangePayloadConverter : JsonConverter<EstimateStateChangePayload>
{
    /// <summary />
    public override EstimateStateChangePayload? Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        throw new NotImplementedException();
    }


    /// <summary />
    public override void Write( Utf8JsonWriter writer, EstimateStateChangePayload value, JsonSerializerOptions options )
    {
        var propName = EstimateEntity.ToPropertyName( value.EstimateType );

        writer.WriteStartObject();
        writer.WritePropertyName( propName );
        JsonSerializer.Serialize( writer, value.Change, options );
        writer.WriteEndObject();
    }
}
