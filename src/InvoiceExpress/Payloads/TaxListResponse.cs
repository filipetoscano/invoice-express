using System.Text.Json.Serialization;

namespace InvoiceExpress.Payloads;

/// <summary />
public class TaxListResponse
{
    /// <summary />
    [JsonPropertyName( "taxes" )]
    public List<Tax> Taxes { get; set; } = default!;
}
