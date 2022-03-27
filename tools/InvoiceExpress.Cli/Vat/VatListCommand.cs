using ConsoleTables;
using McMaster.Extensions.CommandLineUtils;

namespace InvoiceExpress.Cli;

/// <summary />
[Command( "list", Description = "Lists VAT rates" )]
public class VatListCommand
{
    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceExpressClient api, CommandLineApplication app )
    {
        var res = await api.TaxListAsync();


        /*
         * 
         */
        var table = new ConsoleTable( "Id", "Name", "Value", "Region", "D?" );

        foreach ( var r in res.Result! )
            table.AddRow( r.Id, r.Name, r.Value, r.Region, r.IsDefaultTax == true ? "Y" : "N" );

        table.Write( Format.Minimal );

        return 0;
    }
}
