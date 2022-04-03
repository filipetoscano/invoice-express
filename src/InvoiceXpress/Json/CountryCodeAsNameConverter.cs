using InvoiceXpress.Map;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Json;

/// <summary />
public class CountryCodeAsNameConverter : JsonConverter<string>
{
    /// <summary />
    public override string Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        if ( reader.TokenType != JsonTokenType.String )
            throw new JsonException( "Expected string" );

        var name = reader.GetString()!;
        var country = IXCountry.Map.SingleOrDefault( x => x.Name == name );

        if ( country.Code == null )
            throw new JsonException( $"Country '{ name }' is not supported" );

        return country.Code;
    }


    /// <summary />
    public override void Write( Utf8JsonWriter writer, string value, JsonSerializerOptions options )
    {
        var country = IXCountry.Map.SingleOrDefault( x => x.Code == value );

        if ( country.Code == null )
            throw new JsonException( $"Country code '{ value }' is not supported" );

        writer.WriteStringValue( country.Name );
    }
}
