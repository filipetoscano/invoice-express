using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class ItemListPayload
{
    /// <summary />
    [JsonPropertyName( "items" )]
    public List<Item> Items { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "pagination" )]
    public Pagination Pagination { get; set; } = default!;
}
