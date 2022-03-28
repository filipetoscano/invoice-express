using InvoiceXpress.Payloads;
using RestSharp;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<Item>> ItemCreateAsync( Item item )
    {
        var req = new RestRequest( "/items.json" )
            .AddJsonBody( new ItemPayload() { Item = item } );

        var resp = await _rest.PostAsync<ItemPayload>( req );

        return Result( resp!.Item );
    }


    /// <summary />
    public async Task<ApiResult<Item>> ItemGetAsync( int itemId )
    {
        var req = new RestRequest( $"/items/{ itemId }.json" );

        var resp = await _rest.GetAsync<ItemPayload>( req );

        return Result( resp!.Item );
    }


    /// <summary />
    public async Task<ApiResult> ItemUpdateAsync( Item item )
    {
        var req = new RestRequest( $"/items/{ item.Id }.json" )
            .AddJsonBody( new ItemPayload() { Item = item } );

        var resp = await _rest.PutAsync( req );

        return new ApiResult();
    }


    /// <summary />
    public async Task<ApiResult> ItemDeleteAsync( int itemId )
    {
        var req = new RestRequest( $"/items/{ itemId }.json" );

        var resp = await _rest.DeleteAsync( req );

        return new ApiResult();
    }


    /// <summary />
    public async Task<ApiResult<List<Item>>> ItemListAsync( int page, int pageSize = 20 )
    {
        var req = new RestRequest( "/items.json" )
            .AddQueryParameter( "page", page )
            .AddQueryParameter( "per_page", pageSize );

        var resp = await _rest.GetAsync<ItemListPayload>( req );

        return Result( resp!.Items );
    }
}
