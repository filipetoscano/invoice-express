using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class InvoicePayload
{
    /// <summary />
    [JsonPropertyName( "invoice" )]
    public Invoice Invoice { get; set; } = default!;
}
