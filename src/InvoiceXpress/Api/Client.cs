using InvoiceXpress.Payloads;
using RestSharp;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<Client>> ClientCreateAsync( Client client )
    {
        var payload = new ClientPayload() { Client = client };
        var req = new RestRequest( $"/clients.json" )
            .AddJsonBody( payload );

        var resp = await _rest.PostAsync( req );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<ClientPayload>()!;
            return Ok( body.Client );
        }

        return Error<Client>( resp );
    }


    /// <summary />
    public async Task<ApiResult<Client>> ClientGetAsync( int clientId )
    {
        var req = new RestRequest( $"/clients/{ clientId }.json" );

        var resp = await _rest.GetAsync( req );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<ClientPayload>()!;
            return Ok( body.Client );
        }

        return Error<Client>( resp );
    }


    /// <summary />
    public async Task<ApiResult<Client>> ClientGetByCodeAsync( string clientCode )
    {
        var req = new RestRequest( $"/clients/find-by-code.json" )
            .AddQueryParameter( "client_code", clientCode );

        var resp = await _rest.GetAsync( req );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<ClientPayload>()!;
            return Ok( body.Client );
        }

        return Error<Client>( resp );
    }


    /// <summary />
    public async Task<ApiResult> ClientUpdateAsync( Client client )
    {
        var payload = new ClientPayload() { Client = client };
        var req = new RestRequest( $"/clients/{ client.Id }.json" )
            .AddJsonBody( payload );

        var resp = await _rest.PutAsync( req );

        if ( resp.IsSuccessful == true )
            return new ApiResult() { IsSuccessful = resp.IsSuccessful, StatusCode = resp.StatusCode };

        return Error( resp );
    }


    /// <summary />
    public async Task<ApiPaginatedResult<Client>> ClientListAsync( int page, int pageSize = 20 )
    {
        var req = new RestRequest( "/clients.json" )
            .AddQueryParameter( "page", page )
            .AddQueryParameter( "per_page", pageSize );

        var resp = await _rest.GetAsync( req );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<ClientListPayload>()!;
            return Ok( body.Clients, body.Pagination );
        }

        return Error2<Client>( resp );
    }


    /// <summary />
    public async Task<ApiPaginatedResult<Invoice>> ClientInvoiceListAsync( int clientId, int page, int pageSize = 20 )
    {
        var payload = new
        {
            filter = new
            {
                status = new string[] { "final" },
                by_type = new InvoiceType[] { InvoiceType.Invoice, InvoiceType.SimplifiedInvoice, InvoiceType.Receipt },
                archived = new string[] { "non_archived" },
            },
        };

        var req = new RestRequest( $"/clients/{ clientId }/invoices.json" )
            .AddJsonBody( payload )
            .AddQueryParameter( "page", page )
            .AddQueryParameter( "per_page", pageSize );

        var resp = await _rest.PostAsync( req );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<InvoiceListPayload>()!;
            return Ok( body.Invoices, body.Pagination );
        }

        return Error2<Invoice>( resp );
    }
}
