using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace InvoiceExpress.Cli;

/// <summary />
[Command( "get", Description = "Retrieves a client record" )]
public class ClientDetailCommand
{
    /// <summary />
    [Argument( 0, Description = "Client identifier" )]
    [Required]
    public string Identifier { get; set; } = default!;

    /// <summary />
    [Option( "--code", CommandOptionType.NoValue, Description = "Identifier is the code parameter" )]
    public bool IsCode { get; set; } = false;


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceExpressClient api, CommandLineApplication app )
    {
        Client client;

        if ( this.IsCode == true )
        {
            var res = await api.ClientGetByCodeAsync( this.Identifier );
            client = res!.Result!;
        }
        else
        {
            var id = int.Parse( this.Identifier );
            var res = await api.ClientGetAsync( id );

            client = res!.Result!;
        }

        var json = JsonSerializer.Serialize( client, new JsonSerializerOptions() { WriteIndented = true } );
        Console.WriteLine( json );

        return 0;
    }
}
