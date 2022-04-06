using InvoiceXpress.Payloads;
using InvoiceXpress.Rest;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Json;

/// <summary />
public class InvoicePayloadConverter : JsonConverter<InvoicePayload>
{
    /// <summary />
    public override InvoicePayload? Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
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

        if ( InvoiceEntity.IsValidPropertyName( propName ) == false )
            throw new JsonException( $"Unexpected property name '{ propName }' in invoice payload" );


        /*
         * Consume the inner invoice object
         */
        var invoice = (Invoice?) JsonSerializer.Deserialize( ref reader, typeof( Invoice ) );

        if ( invoice == null )
            throw new JsonException( "Expected non-null invoice instance." );


        /*
         * Consume the }
         */
        if ( !reader.Read() || reader.TokenType != JsonTokenType.EndObject )
            throw new JsonException( "Expected end object" );


        /*
         *
         */
        return new InvoicePayload()
        {
            Invoice = invoice,
        };
    }


    /// <summary />
    public override void Write( Utf8JsonWriter writer, InvoicePayload value, JsonSerializerOptions options )
    {
        var propName = InvoiceEntity.ToPropertyName( value.Invoice.Type );

        writer.WriteStartObject();
        writer.WritePropertyName( propName );
        JsonSerializer.Serialize( writer, value.Invoice, options );
        writer.WriteEndObject();
    }
}
