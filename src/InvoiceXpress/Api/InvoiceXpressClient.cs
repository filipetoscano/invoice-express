using HttpTracer;
using HttpTracer.Logger;
using Microsoft.Extensions.Options;
using RestSharp;

namespace InvoiceXpress;

/// <summary />
public partial class InvoiceXpressClient
{
    /// <summary />
    public InvoiceXpressClient( IOptions<InvoiceXpressOptions> options )
    {
        _options = options.Value;


        var rco = new RestClientOptions( $"https://{ _options.AccountName }.app.invoicexpress.com/" )
        {
            ConfigureMessageHandler = handler =>
                new HttpTracerHandler( handler, new ConsoleLogger(), HttpMessageParts.All )
        };

        _rest = new RestClient( rco )
            .UseJson()
            .AddDefaultHeader( "User-Agent", "invoice-xpress-csharp/1.0" )
            .AddDefaultQueryParameter( "api_key", _options.ApiKey );

        _rest.AcceptedContentTypes = new string[] { "application/json" };
    }


    /// <summary />
    private static ApiResult<T> Result<T>( T result )
    {
        return new ApiResult<T>( result );
    }


    private readonly RestClient _rest;
    private readonly InvoiceXpressOptions _options;
}
