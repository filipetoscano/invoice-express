using System.Reflection;
using System.Runtime.Serialization;
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


            /*
             * If no match is found from `SingleOrDefault`, the default for
             * `KeyValuePair` will be returned -- but since that's a struct,
             * it will get initialized with the default values for the given
             * data-types.
             * 
             * And since .Key is an enum, the default value will be the 1st
             * value in the enum! If we want to check that the KVP didn't
             * exist in the collection, we can check if the value is null!
             */
            var kv = map.Value.SingleOrDefault( x => x.Value == v );

            if ( kv.Value == null )
                throw new JsonException( $"Unable to map value '{ v }' to enum '{ typeof( T ) }'" );

            return kv.Key;
        }


        /// <summary />
        public override void Write( Utf8JsonWriter writer, T value, JsonSerializerOptions options )
        {
            var str = map.Value[ value ];

            writer.WriteStringValue( str );
        }


        /// <summary />
        private static Dictionary<T, string> MapBuild()
        {
            var type = typeof( T );
            var map = new Dictionary<T, string>();

            foreach ( T m in Enum.GetValues( type ) )
            {
                var name = m.ToString()!;

                var member = type.GetMember( name )[ 0 ];
                var attr = member.GetCustomAttribute<EnumMemberAttribute>();

                if ( attr != null )
                    map.Add( m, attr.Value! );
                else
                    map.Add( m, name );
            }

            return map;
        }


        private readonly Lazy<Dictionary<T, string>> map = new Lazy<Dictionary<T, string>>( () => MapBuild() );
    }
}
