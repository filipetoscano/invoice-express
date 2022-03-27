using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace InvoiceExpress.Cli;

/// <summary />
[Command( "create", Description = "Create a client record" )]
public class ClientCreateCommand
{
    /// <summary />
    [Argument( 0, Description = "Client record, in JSON file" )]
    [Required]
    [FileExists]
    public string FilePath { get; set; } = default!;


    /// <summary />
    public ClientCreateCommand( InvoiceExpressClient api )
    {
        _api = api;
    }


    /// <summary />
    private async Task<int> OnExecute( CommandLineApplication app )
    {
        /*
         * 
         */
        var json = await File.ReadAllTextAsync( this.FilePath );
        var client = JsonSerializer.Deserialize<Client>( json )!;


        /*
         * 
         */
        var res = await _api.ClientCreateAsync( client );

        Console.WriteLine( res.Result!.Id );

        return 0;
    }


    private readonly InvoiceExpressClient _api;
}
