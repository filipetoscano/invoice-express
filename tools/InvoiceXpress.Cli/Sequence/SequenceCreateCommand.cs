using McMaster.Extensions.CommandLineUtils;
using static InvoiceXpress.Cli.StaticUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "create", Description = "Create a sequence" )]
public class SequenceCreateCommand
{
    /// <summary />
    [Argument( 0, Description = "Sequence record, in JSON file" )]
    [FileExists]
    public string? FilePath { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, Jsonizer jss, IConsole console )
    {
        if ( TryLoad<SequenceData>( console, this.FilePath, jss, out var seq ) == false )
            return 599;


        /*
         * 
         */
        var res = await api.SequenceCreateAsync( seq );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        Console.Write( res.Result!.Id );

        return 0;
    }
}
