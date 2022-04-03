using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class InvoiceStateChange
{
    /// <summary />
    [JsonPropertyName( "state" )]
    public InvoiceAction Action { get; set; }

    /// <summary />
    [JsonPropertyName( "message" )]
    public string Message { get; set; } = default!;
}
