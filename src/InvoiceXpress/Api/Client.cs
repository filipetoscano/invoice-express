using InvoiceXpress.Payloads;
using RestSharp;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public Task<ApiResult<Client>> ClientCreateAsync( Client client )
    {
        throw new NotImplementedException();
    }


    /// <summary />
    public async Task<ApiResult<Client>> ClientGetAsync( int id )
    {
        var req = new RestRequest( $"/clients/{ id }.json" );

        var resp = await _rest.GetAsync<ClientPayload>( req );

        return Result( resp!.Client );
    }


    /// <summary />
    public async Task<ApiResult<Client>> ClientGetByCodeAsync( string code )
    {
        var req = new RestRequest( $"/clients/find-by-code.json" )
            .AddQueryParameter( "client_code", code );

        var resp = await _rest.GetAsync<ClientPayload>( req );

        return Result( resp!.Client );
    }


    /// <summary />
    public Task<ApiResult> ClientUpdateAsync( Client client )
    {
        throw new NotImplementedException();
    }


    /// <summary />
    public async Task<ApiResult<List<Client>>> ClientListAsync( int page, int pageSize = 20 )
    {
        var req = new RestRequest( "/clients.json" )
            .AddQueryParameter( "page", page )
            .AddQueryParameter( "per_page", pageSize );

        var resp = await _rest.GetAsync<ClientListPayload>( req );

        return Result( resp!.Clients );
    }
}
