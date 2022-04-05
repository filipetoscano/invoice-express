using InvoiceXpress.Payloads;
using InvoiceXpress.Rest;
using RestSharp;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<Guide>> GuideCreateAsync( Guide guide )
    {
        var entityName = GuideEntity.ToEntityName( guide.Type );
        var payload = new GuidePayload() { Guide = guide };

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
    public async Task<ApiResult> GuideUpdateAsync( Guide guide )
    {
        var entityName = GuideEntity.ToEntityName( guide.Type );
        var payload = new GuidePayload() { Guide = guide };

        var req = new RestRequest( $"/{ entityName }/{ guide.Id }.json" )
            .AddJsonBody( payload );

        await _rest.PutAsync( req );

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
}
