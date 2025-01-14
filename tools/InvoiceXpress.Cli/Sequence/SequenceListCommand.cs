﻿using ConsoleTables;
using McMaster.Extensions.CommandLineUtils;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "list", Description = "Lists sequences" )]
public class SequenceListCommand
{
    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        var res = await api.SequenceListAsync();

        if ( res.IsSuccessful == false )
            return console.WriteError( res );


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
