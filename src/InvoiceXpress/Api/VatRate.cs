using InvoiceXpress.Payloads;
using RestSharp;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<VatRate>> VatRateCreateAsync( VatRate tax )
    {
        var payload = new
        {
            tax = new VatRateEx()
            {
                Code = tax.Code,
                Value = tax.Value,
                Region = tax.Region,
                IsDefaultRate = tax.IsDefaultRate,
            },
        };

        var req = new RestRequest( "/taxes.json" )
            .AddJsonBody( payload );

        var resp = await _rest.PostAsync<VatRatePayload>( req );

        return Result( resp!.VatRate );
    }


    /// <summary />
    public async Task<ApiResult<VatRate>> VatRateGetAsync( int taxId )
    {
        var req = new RestRequest( $"/taxes/{ taxId }.json" );

        var resp = await _rest.GetAsync<VatRatePayload>( req );

        return Result( resp!.VatRate );
    }


    /// <summary />
    public async Task<ApiResult> VatRateUpdateAsync( VatRate tax )
    {
        var req = new RestRequest( $"/taxes/{ tax.Id }.json" )
            .AddJsonBody( new VatRatePayload() { VatRate = tax } );

        var resp = await _rest.PutAsync( req );

        return new ApiResult();
    }


    /// <summary />
    public async Task<ApiResult> VatRateDeleteAsync( int taxId )
    {
        var req = new RestRequest( $"/taxes/{ taxId }.json" );

        var resp = await _rest.DeleteAsync( req );

        return new ApiResult();
    }


    /// <summary />
    public async Task<ApiResult<List<VatRate>>> VatRateListAsync()
    {
        var req = new RestRequest( "/taxes.json" );

        var resp = await _rest.GetAsync<VatRateListPayload>( req );

        return Result( resp!.VatRates );
    }
}
