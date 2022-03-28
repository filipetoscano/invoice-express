using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceExpress.Cli;

/// <summary />
[Command( "set-default", Description = "Sets a sequence as default" )]
public class SequenceSetDefaultCommand
{
    /// <summary />
    [Argument( 0, Description = "Sequence identifier" )]
    [Required]
    public int SequenceId { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceExpressClient api, CommandLineApplication app )
    {
        /*
         * 
         */
        var res = await api.SequenceSetDefaultAsync( this.SequenceId );

        return 0;
    }
}
