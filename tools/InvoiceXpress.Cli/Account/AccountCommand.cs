using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "account", Description = "Account operations" )]
[Subcommand( typeof( AccountDetailCommand ) )]
[Subcommand( typeof( AccountListCommand ) )]
[Subcommand( typeof( AccountUpdateCommand ) )]
public class AccountCommand
{
    /// <summary />
    private int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();

        return 1;
    }
}
