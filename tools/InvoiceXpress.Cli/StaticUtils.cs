using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
internal static class StaticUtils
{
    /// <summary />
    internal static bool TryLoad<T>( IConsole console, string? file, Jsonizer jss, out T obj )
    {
        /*
         * 
         */
        string json;

        if ( console.IsInputRedirected == true )
        {
            json = console.In.ReadToEnd();
        }
        else if ( file != null )
        {
            json = File.ReadAllText( file );
        }
        else
        {
            console.WriteError( "The FilePath field is required, or pipe JSON to stdin" );

            obj = default!;
            return false;
        };


        /*
         * 
         */
        obj = jss.Deserialize<T>( json );

        return true;
    }
}
