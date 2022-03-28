using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class TaxListPayload
{
    /// <summary />
    [JsonPropertyName( "taxes" )]
    public List<Tax> Taxes { get; set; } = default!;
}
