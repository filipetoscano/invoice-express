using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Json;

/// <summary />
public class EnumConverter : JsonConverterFactory
{
    /// <summary />
    public override bool CanConvert( Type typeToConvert )
    {
        return ( typeToConvert.IsEnum == true );
    }


    /// <summary />
    public override JsonConverter? CreateConverter( Type typeToConvert, JsonSerializerOptions options )
    {
        var tt = typeof( EnumStringConverter<> ).MakeGenericType( typeToConvert );
        var jc = Activator.CreateInstance( tt );

        if ( jc == null )
            throw new InvalidOperationException( $"Failed to create converter for { typeToConvert.FullName }.");

        return (JsonConverter) jc;
    }


    /// <summary />
    public class EnumStringConverter<T> : JsonConverter<T>
        where T : Enum
    {
        /// <summary />
        public EnumStringConverter()
        {
        }


        /// <summary />
        public override T Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
        {
            if ( reader.TokenType != JsonTokenType.String )
                throw new InvalidOperationException( $"Expected 'String' when converting to enum, received '{ reader.TokenType }'" );

            var v = reader.GetString();

            if ( v == null )
                throw new InvalidOperationException( $"Expected non-null value" );

            return JsonEnum<T>.FromValue( v );
        }


        /// <summary />
        public override void Write( Utf8JsonWriter writer, T value, JsonSerializerOptions options )
        {
            var str = JsonEnum<T>.ToValue( value );

            writer.WriteStringValue( str );
        }
    }
}
