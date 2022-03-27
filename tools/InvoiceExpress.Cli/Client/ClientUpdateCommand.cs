using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceExpress.Cli;

/// <summary />
[Command( "update", Description = "Updates a client record" )]
public class ClientUpdateCommand
{
    /// <summary />
    [Argument( 0, Description = "Client record, in JSON file" )]
    [Required]
    [FileExists]
    public string File { get; set; } = default!;


    /// <summary />
    private int OnExecute( CommandLineApplication app )
    {
        return 0;
    }
}
