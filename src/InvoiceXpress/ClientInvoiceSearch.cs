namespace InvoiceXpress;

/// <summary />
public class ClientInvoiceSearch
{
    /// <summary />
    public List<InvoiceState>? States { get; set; }

    /// <summary />
    public List<InvoiceType>? Types { get; set; }

    /// <summary />
    public ArchiveFilter Archive { get; set; } = ArchiveFilter.Active;
}
