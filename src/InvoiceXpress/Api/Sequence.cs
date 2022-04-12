using InvoiceXpress.Payloads;
using RestSharp;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<Sequence>> SequenceCreateAsync( SequenceRef item )
    {
        var req = new RestRequest( "/sequences.json" )
            .AddJsonBody( new SequencePayload<SequenceRef>() { Sequence = item } );

        var resp = await _rest.PostAsync( req );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<SequencePayload<Sequence>>()!;
            return Ok( resp.StatusCode, body.Sequence );
        }

        return Error<Sequence>( resp );
    }


    /// <summary />
    public async Task<ApiResult<Sequence>> SequenceGetAsync( int sequenceId )
    {
        var req = new RestRequest( $"/sequences/{ sequenceId }.json" );

        var resp = await _rest.GetAsync( req );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<SequencePayload<Sequence>>()!;
            return Ok( resp.StatusCode, body.Sequence );
        }

        return Error<Sequence>( resp );
    }


    /// <summary />
    public async Task<ApiResult> SequenceSetDefaultAsync( int sequenceId )
    {
        var req = new RestRequest( $"/sequences/{ sequenceId }/set_current.json" );

        var resp = await _rest.PutAsync( req );

        if ( resp.IsSuccessful == true )
            return Ok( resp.StatusCode );

        return Error( resp );
    }


    /// <summary />
    public async Task<ApiResult<List<Sequence>>> SequenceListAsync()
    {
        var req = new RestRequest( "/sequences.json" );

        var resp = await _rest.GetAsync( req );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<SequenceListPayload>()!;
            return Ok( resp.StatusCode, body.Sequences );
        }

        return Error< List<Sequence>>( resp );
    }
}
