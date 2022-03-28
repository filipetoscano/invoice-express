using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoiceExpress.Json;

/// <summary>
/// Marshals a C# enum as the underlying numeric value, rather
/// than a string representation.
/// </summary>
/// <remarks>
/// In order to safely use this converter, the enumerate definition
/// should explicitly define the numeric value of the enumerate.
/// </remarks>
public class EnumAsNumberConverter : JsonConverterFactory
{
    /// <summary />
    public override bool CanConvert( Type typeToConvert )
    {
        return ( typeToConvert.IsEnum == true );
    }


    /// <summary />
    public override JsonConverter? CreateConverter( Type typeToConvert, JsonSerializerOptions options )
    {
        var tt = typeof( EnumNumberConverter<> ).MakeGenericType( typeToConvert );
        var jc = Activator.CreateInstance( tt );

        if ( jc == null )
            throw new InvalidOperationException();

        return (JsonConverter) jc;
    }


    /// <summary />
    public class EnumNumberConverter<T> : JsonConverter<T>
        where T : Enum
    {
        /// <summary />
        public override T Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
        {
            if ( reader.TokenType != JsonTokenType.Number )
                throw new InvalidOperationException( $"Expected 'Number' when converting to enum, received '{ reader.TokenType }'" );

            var v = reader.GetInt32();

            if ( Enum.IsDefined( typeToConvert, v ) == false )
                throw new InvalidOperationException();

            return (T) Enum.ToObject( typeToConvert, v );
        }


        /// <summary />
        public override void Write( Utf8JsonWriter writer, T value, JsonSerializerOptions options )
        {
            var i = Convert.ToInt32( value );

            writer.WriteNumberValue( i );
        }
    }
}
