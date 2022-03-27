using InvoiceExpress.Payloads;
using RestSharp;

namespace InvoiceExpress;

/// <summary />
public partial class InvoiceExpressClient
{
    /// <summary />
    public async Task<ApiResult<Item>> ItemCreateAsync( Item item )
    {
        await Task.Delay( 0 );

        throw new NotImplementedException();
    }


    /// <summary />
    public async Task<ApiResult<Item>> ItemGetAsync( int itemId )
    {
        var req = new RestRequest( $"/items/{ itemId }.json" );

        var resp = await _rest.GetAsync<ItemGetResponse>( req );

        return Result( resp!.Item );
    }


    /// <summary />
    public async Task<ApiResult<Item>> ItemUpdateAsync( Item item )
    {
        await Task.Delay( 0 );

        throw new NotImplementedException();
    }


    /// <summary />
    public async Task<ApiResult> ItemDeleteAsync( int itemId )
    {
        await Task.Delay( 0 );

        throw new NotImplementedException();
    }
}
