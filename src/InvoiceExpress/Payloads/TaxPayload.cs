using System.Text.Json.Serialization;

namespace InvoiceExpress.Payloads;

/// <summary />
public class TaxPayload
{
    /// <summary />
    [JsonPropertyName( "tax" )]
    public Tax Tax { get; set; } = default!;
}
