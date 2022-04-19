using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "update", Description = "Updates a client record" )]
public class ClientUpdateCommand
{
    /// <summary />
    [Argument( 0, Description = "Client record, in JSON file" )]
    [Required]
    [FileExists]
    public string? FilePath { get; set; }

    /// <summary />
    [Option( "--id", CommandOptionType.SingleValue, Description = "Set client identifier, overriding value in JSON file" )]
    public int? ClientId { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, Jsonizer jss, IConsole console )
    {
        /*
         * 
         */
        var json = await File.ReadAllTextAsync( this.FilePath! );
        var client = jss.Deserialize<Client>( json );

        if ( this.ClientId.HasValue == true )
            client.Id = this.ClientId.Value;


        /*
         * 
         */
        var res = await api.ClientUpdateAsync( client );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        return 0;
    }
}
