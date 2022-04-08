using Microsoft.Extensions.Options;
using RestSharp;
using System.Globalization;
using System.Text.Json;

namespace InvoiceXpress;

/// <summary />
public partial class InvoiceXpressClient : IDisposable
{
    /// <summary />
    public InvoiceXpressClient( IOptions<InvoiceXpressOptions> options, HttpClient client )
    {
        _options = options.Value;


        var rco = new RestClientOptions( $"https://{ _options.AccountName }.app.invoicexpress.com/" )
        {
            ConfigureMessageHandler = _options.ConfigureMessageHandler,
        };

        _rest = new RestClient( rco )
            .UseJson()
            .AddDefaultHeader( "User-Agent", "invoicexpress-dotnet/1.0" )
            .AddDefaultQueryParameter( "api_key", _options.ApiKey );

        _rest.AcceptedContentTypes = new string[] { "application/json" };

        _client = client;
    }


    /// <summary />
    public void Dispose()
    {
        _rest?.Dispose();
        GC.SuppressFinalize( this );
    }


    /// <summary />
    private static ApiResult<T> Result<T>( T result )
    {
        return new ApiResult<T>( result );
    }


    /// <summary />
    private static ApiPaginatedResult<T> Result<T>( List<T> result, Payloads.Pagination pagination )
    {
        return new ApiPaginatedResult<T>( result, new Pagination()
        {
            EntryCount = pagination.EntryCount,
            Page = pagination.Page,
            PageCount = pagination.PageCount,
            PageSize = pagination.PageSize,
        } );
    }


    /// <summary />
    private static string VD( DateOnly value )
    {
        return value.ToString( "dd/MM/yyyy", CultureInfo.InvariantCulture );
    }

    /// <summary />
    private static string VE<T>( T value )
    {
        var v = JsonSerializer.Serialize( value )!;
        return v.Substring( 1, v.Length - 2 );
    }


    private readonly RestClient _rest;
    private readonly HttpClient _client;
    private readonly InvoiceXpressOptions _options;
}
