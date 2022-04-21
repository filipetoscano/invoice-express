using InvoiceXpress.Payloads;
using RestSharp;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<Account>> AccountGetAsync( int accountId,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        var req = new RestRequest( $"/api/accounts/{ accountId }/get.json" );

        var resp = await _rest.ExecuteGetAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
        {
            var body = resp.Response<AccountPayload>()!;
            return Ok( resp.StatusCode, body.Account );
        }

        return Error<Account>( resp );
    }


    /// <summary />
    public async Task<ApiResult> AccountUpdateAsync( Account account,
        CancellationToken cancellationToken = default( CancellationToken ) )
    {
        if ( account.Id.HasValue == false )
            throw new ArgumentException( ".Id property is required when updating an invoice", nameof( account ) );

        var payload = new AccountPayload() { Account = account };
        var req = new RestRequest( $"/api/accounts/{ account.Id }/update.json" )
            .AddJsonBody( payload );

        var resp = await _rest.ExecutePostAsync( req, cancellationToken );

        if ( resp.IsSuccessful == true )
            return Ok( resp.StatusCode );

        return Error( resp );
    }


    /// <summary />
    public async Task<ApiResult<List<Account>>> AccountListAsync( CancellationToken cancellationToken = default( CancellationToken ) )
    {
        await Task.Delay( 0 );

        throw new NotSupportedException();
    }
}
