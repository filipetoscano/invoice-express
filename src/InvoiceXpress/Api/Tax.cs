using InvoiceXpress.Payloads;
using RestSharp;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<Tax>> TaxCreateAsync( Tax tax )
    {
        var req = new RestRequest( "/taxes.json" )
            .AddJsonBody( new TaxPayload() { Tax = tax } );

        var resp = await _rest.PostAsync<TaxPayload>( req );

        return Result( resp!.Tax );
    }


    /// <summary />
    public async Task<ApiResult<Tax>> TaxGetAsync( int taxId )
    {
        var req = new RestRequest( $"/taxes/{ taxId }.json" );

        var resp = await _rest.GetAsync<TaxPayload>( req );

        return Result( resp!.Tax );
    }


    /// <summary />
    public async Task<ApiResult> TaxUpdateAsync( Tax tax )
    {
        var req = new RestRequest( $"/taxes/{ tax.Id }.json" )
            .AddJsonBody( new TaxPayload() { Tax = tax } );

        var resp = await _rest.PutAsync( req );

        return new ApiResult();
    }


    /// <summary />
    public async Task<ApiResult> TaxDeleteAsync( int taxId )
    {
        var req = new RestRequest( $"/taxes/{ taxId }.json" );

        var resp = await _rest.DeleteAsync( req );

        return new ApiResult();
    }


    /// <summary />
    public async Task<ApiResult<List<Tax>>> TaxListAsync()
    {
        var req = new RestRequest( "/taxes.json" );

        var resp = await _rest.GetAsync<TaxListPayload>( req );

        return Result( resp!.Taxes );
    }
}
