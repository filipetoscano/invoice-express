using HttpTracer;
using HttpTracer.Logger;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "invxp", Description = "Execute operations on a invoicexpress account" )]
[Subcommand( typeof( ClientCommand ) )]
[Subcommand( typeof( EstimateCommand ) )]
[Subcommand( typeof( GuideCommand ) )]
[Subcommand( typeof( InvoiceCommand ) )]
[Subcommand( typeof( ItemCommand ) )]
[Subcommand( typeof( SaftCommand ) )]
[Subcommand( typeof( SequenceCommand ) )]
[Subcommand( typeof( VatCommand ) )]
[HelpOption]
[VersionOptionFromMember( MemberName = nameof( GetVersion ) )]
public class Program
{
    /// <summary />
    [Option( "--debug", CommandOptionType.NoValue, Description = "Trace HTTP traffic to console" )]
    public bool Debug { get; set; } = false;


    /// <summary />
    public static int Main( string[] args )
    {
        /*
         * App
         */
        var app = new CommandLineApplication<Program>();


        /*
         * Services
         * Note: .Configure won't run immediately! It will only run when activating
         * the sub-command, at which point the command-line arguments (at the root-level)
         * will have been processed!
         */
        var services = new ServiceCollection();

        services.AddHttpClient<InvoiceXpressClient>();

        services.AddOptions<InvoiceXpressOptions>().Configure( ( opt ) =>
        {
            var apiKey = Environment.GetEnvironmentVariable( "INVXP_APIKEY" );
            var account = Environment.GetEnvironmentVariable( "INVXP_ACCOUNT" );
            var debug = Environment.GetEnvironmentVariable( "INVXP_DEBUG" );

            if ( apiKey == null )
                throw new ConfigException( "Environment variable 'INVXP_APIKEY' not set" );

            if ( account == null )
                throw new ConfigException( "Environment variable 'INVXP_ACCOUNT' not set" );

            opt.AccountName = account;
            opt.ApiKey = apiKey;

            if ( app.Model.Debug == true || debug == "1" )
                opt.ConfigureMessageHandler = handler => new HttpTracerHandler( handler, new ConsoleLogger(), HttpMessageParts.All );
        } );

        services.AddSingleton<InvoiceXpressClient>();

        var sp = services.BuildServiceProvider();


        /*
         * 
         */
        app.Conventions
            .UseDefaultConventions()
            .UseConstructorInjection( sp );

        try
        {
            return app.Execute( args );
        }
        catch ( ConfigException ex )
        {
            Console.WriteLine( "err: " + ex.Message );
            return 7000;
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
    private string GetVersion()
    {
        return typeof( Program ).Assembly!
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()!
            .InformationalVersion;
    }


    /// <summary />
    private int OnExecute( CommandLineApplication app )
    {
        app.ShowHelp();
        return 1;
    }
}
