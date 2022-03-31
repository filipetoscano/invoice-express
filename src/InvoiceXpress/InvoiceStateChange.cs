using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class InvoiceStateChange
{
    /// <summary />
    [JsonPropertyName( "status" )]
    public InvoiceAction Action { get; set; }

    /// <summary />
    public string Message { get; set; } = default!;
}
