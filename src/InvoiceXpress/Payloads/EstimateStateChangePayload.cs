using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class EstimateStateChangePayload
{
    /// <summary />
    [JsonPropertyName( "quote" )]
    public EstimateStateChange Estimate { get; set; } = default!;
}
