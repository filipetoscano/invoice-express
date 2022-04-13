using InvoiceXpress.Payloads;
using RestSharp;
using System.Net;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<string>> SaftExportGenerateAsync( int year, int month,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( "/api/export_saft.json" )
            .AddQueryParameter( "year", year )
            .AddQueryParameter( "month", month );

        var resp = await _rest.ExecutePostAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            /*
             * 200/Ok means that the document has been generated and a download
             * URL is returned in the response.
             * 
             * 202/Accepted means that the document is being generated and the
             * caller must retry until they receive 200/Ok.
             */
            if ( resp.StatusCode == HttpStatusCode.OK )
            {
                var body = resp.Response<SaftExportPayload>()!;
                return Ok<string>( resp.StatusCode, body.Url! );
            }

            return PartialOk<string>( resp.StatusCode, null );
        }

        return Error<string>( resp );
    }


    /// <summary />
    public async Task<ApiResult<byte[]>> SaftExportAsync( int year, int month,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var resp = await SaftExportGenerateAsync( year, month, cancellationToken );
        
        if ( resp.IsSuccessful == false )
            return resp.As<byte[]>();

        if ( resp.StatusCode != HttpStatusCode.OK )
            return resp.As<byte[]>();


        /*
         * TODO: Error handling
         */
        var document = await _client.GetByteArrayAsync( resp.Result! );

        return Ok( HttpStatusCode.OK, document );
    }
}
