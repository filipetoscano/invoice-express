using InvoiceXpress.Payloads;
using InvoiceXpress.Rest;
using RestSharp;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<Estimate>> EstimateCreateAsync( Estimate estimate )
    {
        var entityName = EstimateEntity.ToEntityName( estimate.Type );
        var payload = new EstimatePayload() { Estimate = estimate };

        var req = new RestRequest( $"/{ entityName }.json" )
            .AddJsonBody( payload );

        var resp = await _rest.PostAsync<EstimatePayload>( req );

        if ( resp == null )
            throw new InvalidOperationException();

        return Result( resp.Estimate );
    }


    /// <summary />
    public async Task<ApiResult<Estimate>> EstimateGetAsync( EstimateType type, int estimateId )
    {
        var entityName = EstimateEntity.ToEntityName( type );
        var req = new RestRequest( $"/{ entityName }/{ estimateId }.json" );

        var resp = await _rest.GetAsync<EstimatePayload>( req );

        if ( resp == null )
            throw new InvalidOperationException();

        return Result( resp.Estimate );
    }


    /// <summary />
    public async Task<ApiResult> EstimateUpdateAsync( Estimate estimate )
    {
        var entityName = EstimateEntity.ToEntityName( estimate.Type );
        var payload = new EstimatePayload() { Estimate = estimate };

        var req = new RestRequest( $"/{ entityName }/{ estimate.Id }.json" )
            .AddJsonBody( payload );

        await _rest.PutAsync( req );

        return new ApiResult();
    }


    /// <summary />
    public async Task<ApiResult> EstimateStateChangeAsync( EstimateType type, int estimateId, EstimateStateChange change )
    {
        var entityName = EstimateEntity.ToEntityName( type );
        var payload = new EstimateStateChangePayload()
        {
            EstimateType = type,
            Change = change,
        };

        var req = new RestRequest( $"/{ entityName }/{ estimateId }.json" )
            .AddJsonBody( payload );

        var resp = await _rest.PutAsync( req );

        return new ApiResult();
    }


    /// <summary />
    public async Task<ApiResult<Estimate>> EstimateList( InvoiceSearch search, int page, int pageSize = 20 )
    {
        await Task.Delay( 0 );

        throw new NotImplementedException();
    }
}
