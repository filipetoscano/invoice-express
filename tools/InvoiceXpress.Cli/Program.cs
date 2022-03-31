using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "invxp", Description = "Manage invoicexpress account" )]
[Subcommand( typeof( ClientCommand ) )]
[Subcommand( typeof( EstimateCommand ) )]
[Subcommand( typeof( GuideCommand ) )]
[Subcommand( typeof( InvoiceCommand ) )]
[Subcommand( typeof( ItemCommand ) )]
[Subcommand( typeof( PurchaseOrderCommand ) )]
[Subcommand( typeof( SaftCommand ) )]
[Subcommand( typeof( SequenceCommand ) )]
[Subcommand( typeof( VatCommand ) )]
[HelpOption]
public class Program
{
    /// <summary />
    public static int Main( string[] args )
    {
        /*
         * 
         */
        var apiKey = Environment.GetEnvironmentVariable( "INVEXP_API" );
        var account = Environment.GetEnvironmentVariable( "INVEXP_ACCOUNT" );


        /*
         * Services
         */
        var services = new ServiceCollection();

        services.AddOptions<InvoiceXpressOptions>().Configure( ( opt ) =>
        {
            opt.AccountName = account!;
            opt.ApiKey = apiKey!;
        } );

        services.AddSingleton<InvoiceXpressClient>();

        var sp = services.BuildServiceProvider();


        /*
         * 
         */
        var app = new CommandLineApplication<Program>();

        app.Conventions
            .UseDefaultConventions()
            .UseConstructorInjection( sp );

        try
        {
            return app.Execute( args );
        }
        catch ( UnrecognizedCommandParsingException )
        {
            return 8000;
        }
        catch ( Exception ex )
        {
            Console.WriteLine( "err: " + ex.ToString() );
            return 9000;
        }
    }


    /// <summary />
    private int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();
        return 1;
    }
}
