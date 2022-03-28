using ConsoleTables;
using McMaster.Extensions.CommandLineUtils;

namespace InvoiceExpress.Cli;

/// <summary />
[Command( "list", Description = "Lists sequences" )]
public class SequenceListCommand
{
    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceExpressClient api, CommandLineApplication app )
    {
        var res = await api.SequenceListAsync();


        /*
         * 
         */
        var table = new ConsoleTable( "Id", "Code", "D?" );

        foreach ( var r in res.Result!.OrderBy( x => x.Code ) )
            table.AddRow( r.Id, r.Code, r.IsDefaultSequence ? "Y" : "N" );

        table.Write( Format.Minimal );

        return 0;
    }
}
