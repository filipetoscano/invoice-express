﻿using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "state", Description = "Changes the state of an estimate" )]
public class EstimateStateChangeCommand
{
    /// <summary />
    [Argument( 0, Description = "Estimate type" )]
    [Required]
    public EstimateType? EstimateType { get; set; }

    /// <summary />
    [Argument( 1, Description = "Estimate identifier" )]
    [Required]
    public int? EstimateId { get; set; }

    /// <summary />
    [Argument( 2, Description = "Action, which will change estimate state" )]
    [Required]
    public EstimateAction? Action { get; set; }

    /// <summary />
    [Option( "-m|--message", CommandOptionType.SingleValue, Description = "Message explaining state transition" )]
    public string Message { get; set; } = "Change state";


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        var res = await api.EstimateStateChangeAsync( this.EstimateType!.Value, this.EstimateId!.Value, new EstimateStateChange()
        {
            Action = this.Action!.Value,
            Message = this.Message,
        } );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        return 0;
    }
}
