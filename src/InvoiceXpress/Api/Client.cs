using InvoiceXpress.Payloads;
using RestSharp;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<Client>> ClientCreateAsync( Client client,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var payload = new ClientPayload() { Client = client };
        var req = new RestRequest( $"/clients.json" )
            .AddJsonBody( payload );

        var resp = await _rest.ExecutePostAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<ClientPayload>()!;
            return Ok( resp.StatusCode, body.Client );
        }

        return Error<Client>( resp );
    }


    /// <summary />
    public async Task<ApiResult<Client>> ClientGetAsync( int clientId,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( $"/clients/{ clientId }.json" );

        var resp = await _rest.ExecuteGetAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<ClientPayload>()!;
            return Ok( resp.StatusCode, body.Client );
        }

        return Error<Client>( resp );
    }


    /// <summary />
    public async Task<ApiResult<Client>> ClientGetByCodeAsync( string clientCode,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( $"/clients/find-by-code.json" )
            .AddQueryParameter( "client_code", clientCode );

        var resp = await _rest.ExecuteGetAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<ClientPayload>()!;
            return Ok( resp.StatusCode, body.Client );
        }

        return Error<Client>( resp );
    }


    /// <summary />
    public async Task<ApiResult> ClientUpdateAsync( Client client,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var payload = new ClientPayload() { Client = client };
        var req = new RestRequest( $"/clients/{ client.Id }.json" )
            .AddJsonBody( payload );

        var resp = await _rest.ExecutePutAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
            return Ok( resp.StatusCode );

        return Error( resp );
    }


    /// <summary />
    public async Task<ApiPaginatedResult<Client>> ClientListAsync( int page, int pageSize = 20,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( "/clients.json" )
            .AddQueryParameter( "page", page )
            .AddQueryParameter( "per_page", pageSize );

        var resp = await _rest.ExecuteGetAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<ClientListPayload>()!;
            return Ok( resp.StatusCode, body.Clients, body.Pagination );
        }

        return Error2<Client>( resp );
    }


    /// <summary />
    public async Task<ApiPaginatedResult<Invoice>> ClientInvoiceListAsync( int clientId, ClientInvoiceSearch search, int page, int pageSize = 20,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var archive = new List<string>();

        if ( search.Archive.HasFlag( ArchiveFilter.Active ) == true )
            archive.Add( "non_archived" );

        if ( search.Archive.HasFlag( ArchiveFilter.Archived ) == true )
            archive.Add( "archived" );

        var payload = new ClientInvoiceListPayload();
        payload.Filter = new ClientInvoiceListFilter();
        payload.Filter.States = search.States ?? new List<InvoiceState>() { InvoiceState.Final };
        payload.Filter.Types = search.Types ?? new List<InvoiceType>() { InvoiceType.Invoice, InvoiceType.SimplifiedInvoice };
        payload.Filter.Archive = archive;


        /*
         * 
         */
        var req = new RestRequest( $"/clients/{ clientId }/invoices.json" )
            .AddJsonBody( payload )
            .AddQueryParameter( "page", page )
            .AddQueryParameter( "per_page", pageSize );

        var resp = await _rest.ExecutePostAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<InvoiceListPayload>()!;
            return Ok( resp.StatusCode, body.Invoices, body.Pagination );
        }

        return Error2<Invoice>( resp );
    }
}
