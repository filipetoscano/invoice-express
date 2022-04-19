using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Cli;

/// <summary />
public class Jsonizer
{
    private readonly JsonSerializerOptions _jso;


    /// <summary />
    public Jsonizer()
    {
        _jso = new JsonSerializerOptions();

        _jso.WriteIndented = true;
        _jso.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        _jso.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        _jso.Converters.Add( new JsonStringEnumConverter( JsonNamingPolicy.CamelCase ) );
    }


    /// <summary />
    public string Serialize<T>( T value )
    {
        return JsonSerializer.Serialize<T>( value, _jso );
    }


    /// <summary />
    public T Deserialize<T>( string json )
    {
        return JsonSerializer.Deserialize<T>( json, _jso )!;
    }
}
