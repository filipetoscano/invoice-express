using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
public static class ConsoleExtensions
{
    /// <summary />
    public static int WriteError( this IConsole console, ApiResult res )
    {
        Console.WriteLine( "err: {0}, HTTP {1} {2}", res.ResponseStatus, (int) res.StatusCode, res.StatusCode );

        if ( res.Errors != null )
        {
            foreach ( var err in res.Errors )
                Console.WriteLine( "msg: {0}", err.Message );
        }

        return (int) res.StatusCode;
    }
}
