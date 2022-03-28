using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class EstimatePayload
{
    /// <summary />
    [JsonPropertyName( "quote" )]
    public Estimate Estimate { get; set; } = default!;
}
