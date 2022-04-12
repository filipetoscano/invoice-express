using InvoiceXpress.Payloads;
using RestSharp;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<Sequence>> SequenceCreateAsync( SequenceData item,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( "/sequences.json" )
            .AddJsonBody( new SequencePayload<SequenceData>() { Sequence = item } );

        var resp = await _rest.PostAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<SequencePayload<Sequence>>()!;
            return Ok( resp.StatusCode, body.Sequence );
        }

        return Error<Sequence>( resp );
    }


    /// <summary />
    public async Task<ApiResult<Sequence>> SequenceGetAsync( int sequenceId,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( $"/sequences/{ sequenceId }.json" );

        var resp = await _rest.GetAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<SequencePayload<Sequence>>()!;
            return Ok( resp.StatusCode, body.Sequence );
        }

        return Error<Sequence>( resp );
    }


    /// <summary />
    public async Task<ApiResult> SequenceSetDefaultAsync( int sequenceId,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( $"/sequences/{ sequenceId }/set_current.json" );

        var resp = await _rest.PutAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
            return Ok( resp.StatusCode );

        return Error( resp );
    }


    /// <summary />
    public async Task<ApiResult<List<Sequence>>> SequenceListAsync( CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( "/sequences.json" );

        var resp = await _rest.GetAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<SequenceListPayload>()!;
            return Ok( resp.StatusCode, body.Sequences );
        }

        return Error< List<Sequence>>( resp );
    }
}
