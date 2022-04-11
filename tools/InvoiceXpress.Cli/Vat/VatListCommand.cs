using ConsoleTables;
using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "list", Description = "Lists VAT rates" )]
public class VatListCommand
{
    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        var res = await api.VatRateListAsync();

        if ( res.IsSuccessful == false )
            return console.WriteError( res );


        /*
         * 
         */
        var table = new ConsoleTable( "Id", "Name", "Value", "Region", "D?" );

        foreach ( var r in res.Result! )
            table.AddRow( r.Id, r.Code, r.Value, r.Region, r.IsDefaultRate == true ? "Y" : "N" );

        table.Write( Format.Minimal );

        return 0;
    }
}
