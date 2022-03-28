using System.Text.Json.Serialization;

namespace InvoiceExpress.Payloads;

/// <summary />
public class ReceiptPayload
{
    /// <summary />
    [JsonPropertyName( "receipt" )]
    public Invoice Receipt { get; set; } = default!;
}
