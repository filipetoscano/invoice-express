using InvoiceXpress.Payloads;
using InvoiceXpress.Rest;
using RestSharp;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<Guide>> GuideCreateAsync( GuideData guide )
    {
        var entityName = GuideEntity.ToEntityName( guide.Type );
        var payload = new GuideDataPayload() { Guide = guide };

        var req = new RestRequest( $"/{ entityName }.json" )
            .AddJsonBody( payload );

        var resp = await _rest.PostAsync( req );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<GuidePayload>()!;
            return Ok( resp.StatusCode, body.Guide );
        }

        return Error<Guide>( resp );
    }


    /// <summary />
    public async Task<ApiResult<Guide>> GuideGetAsync( GuideType type, int guideId )
    {
        var entityName = GuideEntity.ToEntityName( type );
        var req = new RestRequest( $"/{ entityName }/{ guideId }.json" );

        var resp = await _rest.GetAsync( req );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<GuidePayload>()!;
            return Ok( resp.StatusCode, body.Guide );
        }

        return Error<Guide>( resp );
    }


    /// <summary />
    public async Task<ApiResult> GuideUpdateAsync( GuideData guide )
    {
        var entityName = GuideEntity.ToEntityName( guide.Type );
        var payload = new GuideDataPayload() { Guide = guide };

        var req = new RestRequest( $"/{ entityName }/{ guide.Id }.json" )
            .AddJsonBody( payload );

        var resp = await _rest.PutAsync( req );

        if ( resp.IsSuccessful == true )
            return Ok( resp.StatusCode );

        return Error( resp );
    }


    /// <summary />
    public async Task<ApiResult> GuideStateChangeAsync( GuideType type, int guideId, GuideStateChange change )
    {
        var entityType = GuideEntity.ToEntityName( type );
        var payload = new GuideStateChangePayload()
        {
            GuideType = type,
            Change = change,
        };

        var req = new RestRequest( $"/{ entityType }/{ guideId }/change-state.json" )
            .AddJsonBody( payload );

        var resp = await _rest.PutAsync( req );

        if ( resp.IsSuccessful == true )
            return Ok( resp.StatusCode );

        return Error( resp );
    }


    /// <summary />
    public async Task<ApiPaginatedResult<Guide>> GuideListAsync( GuideSearch search, int page, int pageSize = 20 )
    {
        var req = new RestRequest( "/guides.json" )
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
            foreach ( var i in Enum.GetValues<GuideType>() )
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
            foreach ( var i in Enum.GetValues<GuideState>() )
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
        var resp = await _rest.GetAsync( req );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<GuideListPayload>()!;
            return Ok( resp.StatusCode, body.Guides, body.Pagination );
        }

        return Error2<Guide>( resp );
    }


    /// <summary />
    public async Task<ApiResult> GuideSendByEmailAsync( GuideType type, int guideId, EmailMessage message )
    {
        var entityName = GuideEntity.ToEntityName( type );
        var payload = EmailMessagePayload.From( message );

        var req = new RestRequest( $"/{ entityName }/{ guideId }/email-document.json" )
            .AddJsonBody( payload );

        var resp = await _rest.PutAsync( req );

        if ( resp.IsSuccessful == true )
            return Ok( resp.StatusCode );

        return Error( resp );
    }


    /// <summary />
    public async Task<ApiResult<PdfDocument>> GuidePdfGenerateAsync( GuideType type, int guideId, bool secondCopy = false )
    {
        var req = new RestRequest( $"/api/pdf/{ guideId }.json" );

        if ( secondCopy == true )
            req.AddQueryParameter( "second_copy", "true" );

        var resp = await _rest.GetAsync( req );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<PdfDocumentPayload>()!;
            return Ok( resp.StatusCode, body.PdfDocument );
        }

        return Error<PdfDocument>( resp );
    }


    /// <summary />
    public async Task<ApiResult<string>> GuideQrCodeUrlAsync( GuideType type, int guideId )
    {
        var req = new RestRequest( $"/api/qr_codes/{ guideId }.json" );

        var resp = await _rest.GetAsync( req );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<QrCodeImagePayload>()!;
            return Ok( resp.StatusCode, body.QrCode.Url );
        }

        return Error<string>( resp );
    }


    /// <summary />
    public async Task<ApiResult<byte[]>> GuideQrCodeImageAsync( GuideType type, int guideId )
    {
        var resp = await GuideQrCodeUrlAsync( type, guideId );

        if ( resp.IsSuccessful == false )
        { 
            return new ApiResult<byte[]>()
            {
                IsSuccessful = resp.IsSuccessful,
                StatusCode = resp.StatusCode,
                Errors = resp.Errors,
            };
        }


        /*
         * 
         */
        var image = await _client.GetByteArrayAsync( resp.Result );

        // TODO: error handling

        return Ok( resp.StatusCode, image );
    }
}
