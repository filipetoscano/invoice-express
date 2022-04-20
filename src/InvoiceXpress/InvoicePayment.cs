using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class InvoicePayment
{
    /// <summary />
    [JsonPropertyName( "payment_mechanism" )]
    [JsonConverter( typeof( EnumConverter ) )]
    public PaymentMethod PaymentMethod { get; set; }

    /// <summary />
    [JsonPropertyName( "note" )]
    public string Remarks { get; set; } = default!;

    /// <summary />
    /// <remarks>
    /// If not specified, will use the same sequence as the associated
    /// invoice.
    /// </remarks>
    [JsonPropertyName( "serie" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public string? SequenceCode { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "amount" )]
    public decimal Amount { get; set; }

    /// <summary />
    [JsonPropertyName( "payment_date" )]
    [JsonConverter( typeof( NonIsoDateConverter ) )]
    public DateOnly Date { get; set; }
}
