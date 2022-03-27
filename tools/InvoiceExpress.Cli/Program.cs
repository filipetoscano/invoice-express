using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceExpress.Cli;

/// <summary />
[Command( "invexp", Description = "Manage halyard accounts" )]
[Subcommand( typeof( ClientCommand ) )]
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
        
        services.AddOptions<InvoiceExpressOptions>().Configure( ( opt ) =>
        {
            opt.AccountName = account!;
            opt.ApiKey = apiKey!;
        } );

        services.AddSingleton<InvoiceExpressClient>();

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
