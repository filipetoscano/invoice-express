using InvoiceXpress.Payloads;
using RestSharp;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<Estimate>> EstimateCreateAsync( Estimate estimate )
    {
        var entityType = ToEntityType( EstimateType.Quote );
        var req = new RestRequest( $"/{ entityType }.json" )
            .AddJsonBody( new EstimatePayload() { Estimate = estimate } );

        var resp = await _rest.PostAsync<EstimatePayload>( req );

        return Result( resp!.Estimate );
    }


    /// <summary />
    public async Task<ApiResult<Estimate>> EstimateGetAsync( EstimateType type, int estimateId )
    {
        var entityType = ToEntityType( type );
        var req = new RestRequest( $"/{ entityType }/{ estimateId }.json" );

        var resp = await _rest.GetAsync<EstimatePayload>( req );

        return Result( resp!.Estimate );
    }


    /// <summary />
    public async Task<ApiResult> EstimateUpdateAsync( Estimate estimate )
    {
        var entityType = ToEntityType( EstimateType.Quote );
        var req = new RestRequest( $"/{ entityType }/{ estimate.Id }.json" )
            .AddJsonBody( new EstimatePayload() { Estimate = estimate } );

        await _rest.PutAsync( req );

        return new ApiResult();
    }


    /// <summary />
    public async Task<ApiResult> EstimateStateChangeAsync( EstimateType type, int estimateId, EstimateStateChange change )
    {
        var entityType = ToEntityType( type );
        var req = new RestRequest( $"/{ entityType }/{ estimateId }.json" )
            .AddJsonBody( new EstimateStateChangePayload() { Estimate = change } );

        var resp = await _rest.PutAsync( req );

        return new ApiResult();
    }


    /// <summary />
    public async Task<ApiResult<Estimate>> EstimateList( InvoiceSearch search, int page, int pageSize = 20 )
    {
        await Task.Delay( 0 );

        throw new NotImplementedException();
    }


    /// <summary />
    private string ToEntityType( EstimateType type )
    {
        switch ( type )
        {
            case EstimateType.Quote:
                return "invoices";

            case EstimateType.Proforma:
                return "proforma";

            case EstimateType.FeeNote:
                return "fee_note";

            default:
                throw new InvalidOperationException();
        }
    }
}
