using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "update", Description = "Updates a client record" )]
public class ClientUpdateCommand
{
    /// <summary />
    [Argument( 0, Description = "Client record, in JSON file" )]
    [Required]
    [FileExists]
    public string FilePath { get; set; } = default!;


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, CommandLineApplication app )
    {
        /*
         * 
         */
        var json = await File.ReadAllTextAsync( this.FilePath );
        var client = JsonSerializer.Deserialize<Client>( json )!;


        /*
         * 
         */
        var res = await api.ClientUpdateAsync( client );

        return 0;
    }
}
