using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class VatRatePayload
{
    /// <summary />
    [JsonPropertyName( "tax" )]
    public VatRate VatRate { get; set; } = default!;
}
