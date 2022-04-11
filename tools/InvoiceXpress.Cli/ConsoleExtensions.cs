using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
public static class ConsoleExtensions
{
    /// <summary />
    public static int WriteError( this IConsole console, ApiResult res )
    {
        if ( res.Errors?.Count() > 0 )
            Console.WriteLine( "err: {0}: {1}", res.StatusCode, res.Errors![ 0 ].Message );
        else
            Console.WriteLine( "err: {0}", res.StatusCode );

        return (int) res.StatusCode;
    }
}
