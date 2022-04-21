using McMaster.Extensions.CommandLineUtils;
using static InvoiceXpress.Cli.StaticUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "update", Description = "Updates an account record" )]
public class AccountUpdateCommand
{
    /// <summary />
    [Argument( 0, Description = "Account record, in JSON file" )]
    [FileExists]
    public string? FilePath { get; set; }

    /// <summary />
    [Option( "--id", CommandOptionType.SingleValue, Description = "Set account identifier, overriding value in JSON file" )]
    public int? AccountId { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, Jsonizer jss, IConsole console )
    {
        if ( TryLoad<Account>( console, this.FilePath, jss, out var account ) == false )
            return 599;

        if ( this.AccountId.HasValue == true )
            account.Id = this.AccountId.Value;


        /*
         * 
         */
        var res = await api.AccountUpdateAsync( account );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        return 0;
    }
}
