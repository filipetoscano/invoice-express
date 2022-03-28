namespace InvoiceExpress;

/// <summary />
public class InvoiceStateChange
{
    /// <summary />
    public InvoiceStatus Status { get; set; }

    /// <summary />
    public string Message { get; set; } = default!;
}
