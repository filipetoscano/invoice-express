using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class VatRateListPayload
{
    /// <summary />
    [JsonPropertyName( "taxes" )]
    public List<VatRate> VatRates { get; set; } = default!;
}
