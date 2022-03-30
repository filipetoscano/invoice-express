using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class Estimate
{
    /// <summary />
    [JsonPropertyName( "id" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public int? Id { get; set; }

    /// <summary />
    [JsonPropertyName( "status" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public EstimateState? State { get; set; }

    /// <summary />
    [JsonPropertyName( "archived" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public bool? IsArchived { get; set; }

    /// <summary />
    [JsonPropertyName( "type" )]
    public EstimateType Type { get; set; }

    /// <summary />
    [JsonPropertyName( "sequence_number" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public string? SequenceNumber { get; set; }

    /// <summary />
    [JsonPropertyName( "date" )]
    [JsonConverter( typeof( NonIsoDateConverter ) )]
    public DateOnly Date { get; set; }

    /// <summary />
    [JsonPropertyName( "due_date" )]
    [JsonConverter( typeof( NonIsoDateConverter ) )]
    public DateOnly DueDate { get; set; }

    /// <summary />
    [JsonPropertyName( "reference" )]
    public string Reference { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "observations" )]
    public string Remarks { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "retention" )]
    public decimal? Retention { get; set; }

    /// <summary />
    [JsonPropertyName( "permalink" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public string? Permalink { get; set; }

    /// <summary />
    [JsonPropertyName( "sum" )]
    public decimal SumAmount { get; set; }

    /// <summary />
    [JsonPropertyName( "discount" )]
    public decimal DiscountAmount { get; set; }

    /// <summary />
    [JsonPropertyName( "before_taxes" )]
    public decimal BeforeTaxesAmount { get; set; }

    /// <summary />
    [JsonPropertyName( "taxes" )]
    public decimal TaxesAmount { get; set; }

    /// <summary>
    /// Total amount, including taxes.
    /// </summary>
    [JsonPropertyName( "total" )]
    public decimal TotalAmount { get; set; }

    /// <summary />
    [JsonPropertyName( "currency" )]
    [JsonConverter( typeof( CurrencyCodeAsNameConverter ) )]
    public string CurrencyCode { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "multicurrency" )]
    public ForeignCurrency? ForeignCurrency { get; set; }

    /// <summary />
    [JsonPropertyName( "client" )]
    public Client Client { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "items" )]
    public List<DocumentItem> Items { get; set; } = default!;
}


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
