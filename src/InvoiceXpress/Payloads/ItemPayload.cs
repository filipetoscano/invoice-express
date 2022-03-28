using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class ItemPayload
{
    /// <summary />
    [JsonPropertyName( "item" )]
    public Item Item { get; set; } = default!;
}
