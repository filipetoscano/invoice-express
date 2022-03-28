using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class ReceiptPayload
{
    /// <summary />
    [JsonPropertyName( "receipt" )]
    public Invoice Receipt { get; set; } = default!;
}
