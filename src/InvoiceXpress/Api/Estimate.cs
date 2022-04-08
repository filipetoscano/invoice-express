using InvoiceXpress.Payloads;
using InvoiceXpress.Rest;
using RestSharp;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<Estimate>> EstimateCreateAsync( EstimateData estimate )
    {
        if ( estimate.Id.HasValue == true )
            throw new ArgumentException( ".Id property is prohibited when creating an estimate", nameof( estimate ) );

        var entityName = EstimateEntity.ToEntityName( estimate.Type );
        var payload = new EstimateDataPayload() { Estimate = estimate };

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
    public async Task<ApiResult> EstimateUpdateAsync( EstimateData estimate )
    {
        if ( estimate.Id.HasValue == false )
            throw new ArgumentException( ".Id property is required when updating an estimate", nameof( estimate ) );

        var entityName = EstimateEntity.ToEntityName( estimate.Type );
        var payload = new EstimateDataPayload() { Estimate = estimate };

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

        var req = new RestRequest( $"/{ entityName }/{ estimateId }/change-state.json" )
            .AddJsonBody( payload );

        var resp = await _rest.PutAsync( req );

        return new ApiResult();
    }


    /// <summary />
    public async Task<ApiPaginatedResult<Estimate>> EstimateListAsync( EstimateSearch search, int page, int pageSize = 20 )
    {
        var req = new RestRequest( "/estimates.json" )
            .AddQueryParameter( "page", page )
            .AddQueryParameter( "per_page", pageSize );

        if ( search.Text != null )
            req.AddQueryParameter( "text", search.Text );

        /*
         * type[] is a required parameter. If not explicitly specified,
         * return all types of invoices.
         */
        if ( search.Type != null && search.Type.Count > 0 )
        {
            foreach ( var i in search.Type.Distinct() )
                req.AddQueryParameter( "type[]", VE( i ) );
        }
        else
        {
            foreach ( var i in Enum.GetValues<EstimateType>() )
                req.AddQueryParameter( "type[]", VE( i ) );
        }


        /*
         * status[] is a required parameter. If not explicitly specified,
         * return all states.
         */
        if ( search.State != null && search.State.Count > 0 )
        {
            foreach ( var i in search.State.Distinct() )
                req.AddQueryParameter( "status[]", VE( i ) );
        }
        else
        {
            foreach ( var i in Enum.GetValues<EstimateState>() )
                req.AddQueryParameter( "status[]", VE( i ) );
        }

        if ( search.DateFrom.HasValue == true )
            req.AddQueryParameter( "date[from]", VD( search.DateFrom.Value ) );

        if ( search.DateTo.HasValue == true )
            req.AddQueryParameter( "date[to]", VD( search.DateTo.Value ) );

        if ( search.DueDateFrom.HasValue == true )
            req.AddQueryParameter( "due_date[from]", VD( search.DueDateFrom.Value ) );

        if ( search.DueDateTo.HasValue == true )
            req.AddQueryParameter( "due_date[to]", VD( search.DueDateTo.Value ) );

        if ( search.TotalBeforeTaxesFrom.HasValue == true )
            req.AddQueryParameter( "total_before_taxes[from]", search.TotalBeforeTaxesFrom.Value );

        if ( search.TotalBeforeTaxesTo.HasValue == true )
            req.AddQueryParameter( "total_before_taxes[to]", search.TotalBeforeTaxesTo.Value );

        if ( search.Reference != null )
            req.AddQueryParameter( "reference", search.Reference );

        /*
         * non_archived is a required parameter
         */
        if ( search.Archive.HasValue == true )
        {
            req.AddQueryParameter( "non_archived", search.Archive.Value.HasFlag( ArchiveFilter.Active ) == true ? "true" : "false" );
            req.AddQueryParameter( "archived", search.Archive.Value.HasFlag( ArchiveFilter.Archived ) == true ? "true" : "false" );
        }
        else
        {
            req.AddQueryParameter( "non_archived", "true" );
        }


        /*
         * 
         */
        var resp = await _rest.GetAsync<EstimateListPayload>( req );

        return Result( resp!.Estimates, resp.Pagination );
    }


    /// <summary />
    public async Task<ApiResult> EstimateSendByEmailAsync( EstimateType type, int estimateId, EmailMessage message )
    {
        var entityName = EstimateEntity.ToEntityName( type );
        var payload = EmailMessagePayload.From( message );

        var req = new RestRequest( $"/{ entityName }/{ estimateId }/email-document.json" )
            .AddJsonBody( payload );

        await _rest.PutAsync( req );

        return new ApiResult();
    }


    /// <summary />
    public async Task<ApiResult<PdfDocument>> EstimatePdfGenerateAsync( EstimateType type, int estimateId, bool secondCopy = false )
    {
        var req = new RestRequest( $"/api/pdf/{ estimateId }.json" );

        if ( secondCopy == true )
            req.AddQueryParameter( "second_copy", "true" );

        var resp = await _rest.GetAsync<PdfDocumentPayload>( req );

        return Result( resp!.PdfDocument );
    }
}
