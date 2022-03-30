using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class ForeignCurrency
{
    /// <summary />
    [JsonPropertyName( "rate" )]
    public decimal ExchangeRage { get; set; }

    /// <summary />
    [JsonPropertyName( "currency" )]
    public string CurrencyCode { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "total" )]
    public decimal TotalAmount { get; set; }
}
