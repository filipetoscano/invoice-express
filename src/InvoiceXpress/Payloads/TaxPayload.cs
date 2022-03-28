using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class TaxPayload
{
    /// <summary />
    [JsonPropertyName( "tax" )]
    public Tax Tax { get; set; } = default!;
}
