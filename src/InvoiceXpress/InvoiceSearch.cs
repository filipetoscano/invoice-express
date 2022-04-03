namespace InvoiceXpress;

/// <summary />
public struct InvoiceSearch
{
    /// <summary />
    public string? Text { get; set; }

    /// <summary />
    public List<InvoiceType>? Type { get; set; }

    /// <summary />
    public List<InvoiceState>? State { get; set; }

    /// <summary />
    public DateOnly? DateFrom { get; set; }

    /// <summary />
    public DateOnly? DateTo { get; set; }

    /// <summary />
    public DateOnly? DueDateFrom { get; set; }

    /// <summary />
    public DateOnly? DueDateTo { get; set; }

    /// <summary />
    public decimal? TotalBeforeTaxesFrom { get; set; }

    /// <summary />
    public decimal? TotalBeforeTaxesTo { get; set; }

    /// <summary />
    public string? Reference { get; set; }


    /// <summary />
    public void AddType( InvoiceType type )
    {
        if ( Type == null )
            Type = new List<InvoiceType>();

        Type.Add( type );
    }


    /// <summary />
    public void AddState( InvoiceState state )
    {
        if ( State == null )
            State = new List<InvoiceState>();

        State.Add( state );
    }
}
