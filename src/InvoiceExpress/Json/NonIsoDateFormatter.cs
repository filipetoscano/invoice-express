using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoiceExpress;

/// <summary>
/// Marshals C# date to the non-ISO date format.
/// </summary>
/// <remarks>
/// invoicexpress expects date in dd/MM/yyyy format, rather than yyyy-MM-dd.
/// </remarks>
public class NonIsoDateFormatter : JsonConverter<DateOnly>
{
    /// <summary />
    public override DateOnly Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        var str = reader.GetString();

        if ( str == null )
            throw new InvalidOperationException();

        return DateOnly.ParseExact( str, "dd/MM/yyyy", CultureInfo.InvariantCulture );
    }


    /// <summary />
    public override void Write( Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options )
    {
        var str = value.ToString( "dd/MM/yyyy", CultureInfo.InvariantCulture );

        writer.WriteStringValue( str );
    }
}
