using HttpTracer;
using HttpTracer.Logger;
using InvoiceExpress.Payloads;
using Microsoft.Extensions.Options;
using RestSharp;

namespace InvoiceExpress;

/// <summary />
public class InvoiceExpressClient
{
    /// <summary />
    public InvoiceExpressClient( IOptions<InvoiceExpressOptions> options )
    {
        _options = options.Value;


        var rco = new RestClientOptions( $"https://{ _options.AccountName }.app.invoicexpress.com/" )
        {
            ConfigureMessageHandler = handler =>
                new HttpTracerHandler( handler, new ConsoleLogger(), HttpMessageParts.All )
        };

        _rest = new RestClient( rco )
            .UseJson()
            .AddDefaultHeader( "User-Agent", "invoice-express-csharp" )
            .AddDefaultQueryParameter( "api_key", _options.ApiKey );
    }


    /// <summary />
    public Task<ApiResult<Client>> ClientCreateAsync( Client client )
    {
        throw new NotImplementedException();
    }


    /// <summary />
    public Task<ApiResult> ClientUpdateAsync( Client client )
    {
        throw new NotImplementedException();
    }


    /// <summary />
    public async Task<ApiResult<List<Client>>> ClientListAsync( int page, int pageSize )
    {
        var req = new RestRequest( "/clients.json" )
            .AddQueryParameter( "page", page )
            .AddQueryParameter( "per_page", pageSize );

        var resp = await _rest.GetAsync<ClientsListResponse>( req );

        return Result( resp!.Clients );
    }


    /// <summary />
    public async Task<ApiResult<Client>> ClientGetAsync( int id )
    {
        var req = new RestRequest( $"/clients/{ id }.json" );

        var resp = await _rest.GetAsync<ClientGetResponse>( req );

        return Result( resp!.Client );
    }


    /// <summary />
    public async Task<ApiResult<Client>> ClientGetByCodeAsync( string code )
    {
        var req = new RestRequest( $"/clients/find-by-code.json" )
            .AddQueryParameter( "client_code", code );

        var resp = await _rest.GetAsync<ClientGetResponse>( req );

        return Result( resp!.Client );
    }


    /// <summary />
    /// <remarks>
    /// See https://www.invoicexpress.com/api-v2/invoices/get
    /// </remarks>
    public Task<ApiResult<Invoice>> InvoiceGetAsync( InvoiceType type, int invoiceId )
    {
        throw new NotImplementedException();
    }


    /// <summary />
    /// <remarks>
    /// See https://www.invoicexpress.com/api-v2/invoices/create
    /// </remarks>
    public Task<ApiResult<Invoice>> InvoiceCreate( Invoice invoice )
    {
        throw new NotImplementedException();
    }


    /// <summary />
    private static ApiResult<T> Result<T>( T result )
    {
        return new ApiResult<T>( result );
    }


    private readonly RestClient _rest;
    private readonly InvoiceExpressOptions _options;
}
