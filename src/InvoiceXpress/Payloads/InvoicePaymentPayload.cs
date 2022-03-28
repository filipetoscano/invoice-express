using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class InvoicePaymentPayload
{
    /// <summary />
    [JsonPropertyName( "partial_payment" )]
    public InvoicePayment Payment { get; set; } = default!;
}
