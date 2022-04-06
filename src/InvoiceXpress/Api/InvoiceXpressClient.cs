using Microsoft.Extensions.Options;
using RestSharp;

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

    private readonly RestClient _rest;
    private readonly HttpClient _client;
    private readonly InvoiceXpressOptions _options;
}
