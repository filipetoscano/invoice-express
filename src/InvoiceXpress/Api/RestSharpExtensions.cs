using RestSharp;
using System.Text.Json;

namespace InvoiceXpress;

/// <summary />
internal static class RestSharpExtensions
{
    /// <summary />
    internal static T Response<T>( this RestResponse response )
    {
        if ( response.Content == null )
            throw new InvalidOperationException( "Expected .Content to be non-null" );

        return JsonSerializer.Deserialize<T>( response.Content )!;
    }
}
