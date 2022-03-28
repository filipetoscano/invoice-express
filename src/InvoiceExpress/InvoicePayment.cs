using InvoiceExpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceExpress;

public class InvoicePayment
{
    /// <summary />
    [JsonPropertyName( "payment_mechanism" )]
    public PaymentMethod PaymentMethod { get; set; }

    /// <summary />
    [JsonPropertyName( "note" )]
    public string Remarks { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "serie" )]
    public string Serie { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "amount" )]
    public decimal Amount { get; set; }

    /// <summary />
    [JsonPropertyName( "payment_date" )]
    [JsonConverter( typeof( NonIsoDateConverter ) )]
    public DateOnly Date { get; set; }
}
