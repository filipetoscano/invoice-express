using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Json;

/// <summary />
public class DecimalAsStringConverter : JsonConverter<decimal>
{
    /// <summary />
    public override decimal Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        var str = reader.GetString();

        if ( str == null )
            throw new InvalidOperationException();

        return decimal.Parse( str );
    }


    /// <summary />
    public override void Write( Utf8JsonWriter writer, decimal value, JsonSerializerOptions options )
    {
        var str = value.ToString( CultureInfo.InvariantCulture );
        writer.WriteStringValue( str );
    }
}
