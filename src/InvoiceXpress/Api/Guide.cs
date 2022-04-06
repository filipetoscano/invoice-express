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

        var resp = await _rest.PostAsync<GuidePayload>( req );

        return Result( resp!.Guide );
    }


    /// <summary />
    public async Task<ApiResult<Guide>> GuideGetAsync( GuideType type, int guideId )
    {
        var entityName = GuideEntity.ToEntityName( type );
        var req = new RestRequest( $"/{ entityName }/{ guideId }.json" );

        var resp = await _rest.GetAsync<GuidePayload>( req );

        return Result( resp!.Guide );
    }


    /// <summary />
    public async Task<ApiResult> GuideUpdateAsync( GuideData guide )
    {
        var entityName = GuideEntity.ToEntityName( guide.Type );
        var payload = new GuideDataPayload() { Guide = guide };

        var req = new RestRequest( $"/{ entityName }/{ guide.Id }.json" )
            .AddJsonBody( payload );

        await _rest.PutAsync( req );

        return new ApiResult();
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

        return new ApiResult();
    }


    /// <summary />
    public async Task<ApiResult<List<Guide>>> GuideListAsync( int page, int pageSize = 20 )
    {
        var req = new RestRequest( "/guides.json" )
            .AddQueryParameter( "page", page )
            .AddQueryParameter( "per_page", pageSize );

        var resp = await _rest.GetAsync<GuideListPayload>( req );

        return Result( resp!.Guides );
    }


    /// <summary />
    public async Task<ApiResult> GuideSendByEmailAsync( GuideType type, int guideId, EmailMessage message )
    {
        var entityName = GuideEntity.ToEntityName( type );
        var payload = EmailMessagePayload.From( message );

        var req = new RestRequest( $"/{ entityName }/{ guideId }/email-document.json" )
            .AddJsonBody( payload );

        await _rest.PutAsync( req );

        return new ApiResult();
    }


    /// <summary />
    public async Task<ApiResult<PdfDocument>> GuidePdfGenerateAsync( GuideType type, int guideId, bool secondCopy = false )
    {
        var req = new RestRequest( $"/api/pdf/{ guideId }.json" );

        if ( secondCopy == true )
            req.AddQueryParameter( "second_copy", "true" );

        var resp = await _rest.GetAsync<PdfDocumentPayload>( req );

        return Result( resp!.PdfDocument );
    }


    /// <summary />
    public async Task<ApiResult<string>> GuideQrCodeUrlAsync( GuideType type, int guideId )
    {
        var req = new RestRequest( $"/api/qr_codes/{ guideId }.json" );

        var resp = await _rest.GetAsync<QrCodeImagePayload>( req );

        return Result( resp!.QrCode.Url );
    }


    /// <summary />
    public async Task<ApiResult<byte[]>> GuideQrCodeImageAsync( GuideType type, int guideId )
    {
        var resp = await GuideQrCodeUrlAsync( type, guideId );

        var image = await _client.GetByteArrayAsync( resp.Result );

        return Result( image );
    }
}
