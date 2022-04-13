using InvoiceXpress.Payloads;
using RestSharp;
using System.Net;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<string?>> SaftExportGenerateAsync( int year, int month,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( "/api/export_saft.json" )
            .AddQueryParameter( "year", year )
            .AddQueryParameter( "month", month );

        var resp = await _rest.ExecutePostAsync( req, cancellationToken );


        /*
         * Export is finished and available for download.
         */
        if ( resp.StatusCode == HttpStatusCode.OK )
        {
            var body = resp.Response<SaftExportPayload>()!;
            return Ok( resp.StatusCode, body.Url );
        }


        /*
         * Command has been accepted: export will begin. Caller
         * should continue to invoke method until `OK` is returned.
         */
        if ( resp.StatusCode == HttpStatusCode.Accepted )
            return Ok<string?>( resp.StatusCode, null );

        return Error<string?>( resp );
    }


    /// <summary />
    public async Task<ApiResult<byte[]>> SaftExportAsync( int year, int month,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var inner = SaftExportGenerateAsync( year, month, cancellationToken );

        await Task.Delay( 0 );

        throw new NotImplementedException();
    }
}
