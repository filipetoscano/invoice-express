using InvoiceExpress.Payloads;
using RestSharp;

namespace InvoiceExpress;

public partial class InvoiceExpressClient
{
    /// <summary />
    public async Task<ApiResult<Sequence>> SequenceCreateAsync( SequenceRef item )
    {
        var req = new RestRequest( "/sequences.json" )
            .AddJsonBody( new SequencePayload<SequenceRef>() { Sequence = item } );

        var resp = await _rest.PostAsync<SequencePayload<Sequence>>( req );

        return Result( resp!.Sequence );
    }


    /// <summary />
    public async Task<ApiResult<Sequence>> SequenceGetAsync( int sequenceId )
    {
        var req = new RestRequest( $"/sequences/{ sequenceId }.json" );

        var resp = await _rest.GetAsync<SequencePayload<Sequence>>( req );

        return Result( resp!.Sequence );
    }


    /// <summary />
    public async Task<ApiResult> SequenceSetDefaultAsync( int sequenceId )
    {
        var req = new RestRequest( $"/sequences/{ sequenceId }/set_current.json" );

        var resp = await _rest.PutAsync( req );

        return new ApiResult();
    }


    /// <summary />
    public async Task<ApiResult<List<Sequence>>> SequenceListAsync()
    {
        var req = new RestRequest( "/sequences.json" );

        var resp = await _rest.GetAsync<SequenceListPayload>( req );

        return Result( resp!.Sequences );
    }
}
