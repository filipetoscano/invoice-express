using McMaster.Extensions.CommandLineUtils;
using static InvoiceXpress.Cli.StaticUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "create", Description = "Create an estimate" )]
public class EstimateCreateCommand
{
    /// <summary />
    [Argument( 0, Description = "Estimate record, in JSON file" )]
    [FileExists]
    public string? FilePath { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, Jsonizer jss, IConsole console )
    {
        if ( TryLoad<EstimateData>( console, this.FilePath, jss, out var estimate ) == false )
            return 599;


        /*
         * 
         */
        var res = await api.EstimateCreateAsync( estimate );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        Console.WriteLine( res.Result!.Id );

        return 0;
    }
}
