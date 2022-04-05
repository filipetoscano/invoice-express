using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class GuideListPayload
{
    /// <summary />
    [JsonPropertyName( "guides" )]
    public List<Guide> Guides { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "pagination" )]
    public Pagination Pagination { get; set; } = default!;
}
