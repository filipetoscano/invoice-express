using InvoiceXpress.Payloads;
using RestSharp;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<Item>> ItemCreateAsync( Item item,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( "/items.json" )
            .AddJsonBody( new ItemPayload() { Item = item } );

        var resp = await _rest.ExecutePostAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<ItemPayload>()!;
            return Ok( resp.StatusCode, body.Item );
        }

        return Error<Item>( resp );
    }


    /// <summary />
    public async Task<ApiResult<Item>> ItemGetAsync( int itemId,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( $"/items/{ itemId }.json" );

        var resp = await _rest.ExecuteGetAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<ItemPayload>()!;
            return Ok( resp.StatusCode, body.Item );
        }

        return Error<Item>( resp );
    }


    /// <summary />
    public async Task<ApiResult> ItemUpdateAsync( Item item,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( $"/items/{ item.Id }.json" )
            .AddJsonBody( new ItemPayload() { Item = item } );

        var resp = await _rest.ExecutePutAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
            return Ok( resp.StatusCode );

        return Error( resp );
    }


    /// <summary />
    public async Task<ApiResult> ItemDeleteAsync( int itemId,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( $"/items/{ itemId }.json", Method.Delete );

        var resp = await _rest.ExecuteAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
            return Ok( resp.StatusCode );

        return Error( resp );
    }


    /// <summary />
    public async Task<ApiPaginatedResult<Item>> ItemListAsync( int page, int pageSize = 20,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( "/items.json" )
            .AddQueryParameter( "page", page )
            .AddQueryParameter( "per_page", pageSize );

        var resp = await _rest.ExecuteGetAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<ItemListPayload>()!;

            // #19: Item/List all doesn't return pagination
            var p = new Payloads.Pagination();

            return Ok( resp.StatusCode, body.Items, p );
        }

        return Error2<Item>( resp );
    }
}
