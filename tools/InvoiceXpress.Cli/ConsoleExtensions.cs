using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
public static class ConsoleExtensions
{
    /// <summary />
    public static int WriteError( this IConsole console, ApiResult res )
    {
        if ( res.StatusCode != 0 )
            Console.WriteLine( "err: {0}, HTTP {1} {2}", res.ResponseStatus, (int) res.StatusCode, res.StatusCode );
        else
            Console.WriteLine( "err: {0}", res.ResponseStatus );

        // Other types of errors!
        if ( res.ErrorException != null )
        {
            Console.WriteLine( res.ErrorException.GetType().FullName );
            Console.WriteLine( res.ErrorException.Message );
        }

        // API errors, as returned by invoicexpress
        if ( res.Errors != null )
        {
            foreach ( var err in res.Errors )
                Console.WriteLine( "msg: {0}", err.Message );
        }

        return (int) res.StatusCode;
    }


    /// <summary />
    public static int WriteError( this IConsole console, string message )
    {
        var fg = console.ForegroundColor;
        console.ForegroundColor = ConsoleColor.Red;

        console.WriteLine( message );

        console.ForegroundColor = fg;

        return 599;
    }
}
