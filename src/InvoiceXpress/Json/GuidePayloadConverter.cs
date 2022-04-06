using InvoiceXpress.Payloads;
using InvoiceXpress.Rest;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Json;

/// <summary />
public class GuidePayloadConverter : JsonConverter<GuidePayload>
{
    /// <summary />
    public override GuidePayload? Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
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

        if ( GuideEntity.IsValidPropertyName( propName ) == false )
            throw new JsonException( $"Unexpected property name '{ propName }' in guide payload" );


        /*
         * Consume the inner estimate object
         */
        var guide = (Guide?) JsonSerializer.Deserialize( ref reader, typeof( Guide ) );

        if ( guide == null )
            throw new JsonException( "Expected non-null estimate instance." );


        /*
         * Consume the }
         */
        if ( !reader.Read() || reader.TokenType != JsonTokenType.EndObject )
            throw new JsonException( "Expected end object" );


        /*
         *
         */
        return new GuidePayload()
        {
            Guide = guide,
        };
    }


    /// <summary />
    public override void Write( Utf8JsonWriter writer, GuidePayload value, JsonSerializerOptions options )
    {
        var propName = GuideEntity.ToPropertyName( value.Guide.Type );

        writer.WriteStartObject();
        writer.WritePropertyName( propName );
        JsonSerializer.Serialize( writer, value.Guide, options );
        writer.WriteEndObject();
    }
}
