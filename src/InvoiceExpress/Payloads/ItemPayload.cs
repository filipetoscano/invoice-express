using System.Text.Json.Serialization;

namespace InvoiceExpress.Payloads;

/// <summary />
public class ItemPayload
{
    /// <summary />
    [JsonPropertyName( "item" )]
    public Item Item { get; set; } = default!;
}
