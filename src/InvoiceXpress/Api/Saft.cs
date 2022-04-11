using InvoiceXpress.Payloads;
using RestSharp;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<string>> SaftExportAsync( int year, int month )
    {
        var req = new RestRequest( "/api/export_saft.json" )
            .AddQueryParameter( "year", year )
            .AddQueryParameter( "month", month );

        var resp = await _rest.PostAsync<SaftExportPayload>( req );

        return Ok( resp!.Url! );
    }
}
