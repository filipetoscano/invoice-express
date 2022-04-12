﻿using InvoiceXpress.Payloads;
using RestSharp;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<Item>> ItemCreateAsync( Item item )
    {
        var req = new RestRequest( "/items.json" )
            .AddJsonBody( new ItemPayload() { Item = item } );

        var resp = await _rest.PostAsync( req );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<ItemPayload>()!;
            return Ok( resp.StatusCode, body.Item );
        }

        return Error<Item>( resp );
    }


    /// <summary />
    public async Task<ApiResult<Item>> ItemGetAsync( int itemId )
    {
        var req = new RestRequest( $"/items/{ itemId }.json" );

        var resp = await _rest.GetAsync( req );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<ItemPayload>()!;
            return Ok( resp.StatusCode, body.Item );
        }

        return Error<Item>( resp );
    }


    /// <summary />
    public async Task<ApiResult> ItemUpdateAsync( Item item )
    {
        var req = new RestRequest( $"/items/{ item.Id }.json" )
            .AddJsonBody( new ItemPayload() { Item = item } );

        var resp = await _rest.PutAsync( req );

        if ( resp.IsSuccessful == true )
            return Ok( resp.StatusCode );

        return Error( resp );
    }


    /// <summary />
    public async Task<ApiResult> ItemDeleteAsync( int itemId )
    {
        var req = new RestRequest( $"/items/{ itemId }.json" );

        var resp = await _rest.DeleteAsync( req );

        if ( resp.IsSuccessful == true )
            return Ok( resp.StatusCode );

        return Error( resp );
    }


    /// <summary />
    public async Task<ApiPaginatedResult<Item>> ItemListAsync( int page, int pageSize = 20 )
    {
        var req = new RestRequest( "/items.json" )
            .AddQueryParameter( "page", page )
            .AddQueryParameter( "per_page", pageSize );

        var resp = await _rest.GetAsync( req );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<ItemListPayload>()!;
            return Ok( resp.StatusCode, body.Items, body.Pagination );
        }

        return Error2<Item>( resp );
    }
}
