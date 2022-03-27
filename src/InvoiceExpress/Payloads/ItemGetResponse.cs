using System.Text.Json.Serialization;

namespace InvoiceExpress.Payloads;

/// <summary />
public class ItemGetResponse
{
    /// <summary />
    [JsonPropertyName( "item" )]
    public Item Item { get; set; } = default!;
}
