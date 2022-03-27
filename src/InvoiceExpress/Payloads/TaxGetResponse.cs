using System.Text.Json.Serialization;

namespace InvoiceExpress.Payloads;

/// <summary />
public class TaxGetResponse
{
    /// <summary />
    [JsonPropertyName( "tax" )]
    public Tax Tax { get; set; } = default!;
}
