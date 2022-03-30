using InvoiceXpress.Payloads;
using InvoiceXpress.Rest;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Json;

/// <summary />
public class EstimatePayloadConverter : JsonConverter<EstimatePayload>
{
    /// <summary />
    public override EstimatePayload? Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        /*
         * Consume the {
         */
        if ( reader.TokenType != JsonTokenType.StartObject )
            throw new JsonException( "Expected start object" );


        /*
         * Consume the property name
         */
        if ( !reader.Read() || reader.TokenType != JsonTokenType.PropertyName )
            throw new JsonException( "Expected property name" );

        var propName = reader.GetString()!;

        if ( EstimateEntity.IsValidPropertyName( propName ) == false )
            throw new JsonException( $"Unexpected property name '{ propName }' in estimate payload" );


        /*
         * Consume the inner estimate object
         */
        var estimate = (Estimate?) JsonSerializer.Deserialize( ref reader, typeof( Estimate ) );

        if ( estimate == null )
            throw new JsonException( "Expected non-null estimate instance." );


        /*
         * Consume the }
         */
        if ( !reader.Read() || reader.TokenType != JsonTokenType.EndObject )
            throw new JsonException( "Expected end object" );


        /*
         *
         */
        return new EstimatePayload()
        {
            Estimate = estimate,
        };
    }


    /// <summary />
    public override void Write( Utf8JsonWriter writer, EstimatePayload value, JsonSerializerOptions options )
    {
        var elementName = EstimateEntity.ToElementName( value.Estimate.Type );

        writer.WriteStartObject();
        writer.WritePropertyName( elementName );
        JsonSerializer.Serialize( writer, value.Estimate, options );
        writer.WriteEndObject();
    }
}
