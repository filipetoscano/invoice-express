using InvoiceXpress.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class Invoice
{
    /// <summary />
    [JsonPropertyName( "id" )]
    public int? Id { get; set; }

    /// <summary />
    [JsonPropertyName( "status" )]
    public InvoiceState? State { get; set; }

    /// <summary />
    [JsonPropertyName( "archived" )]
    public bool? IsArchived { get; set; }

    /// <summary />
    [JsonPropertyName( "type" )]
    public InvoiceType Type { get; set; }

    /// <summary />
    [JsonPropertyName( "sequence_number" )]
    public string SequenceNumber { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "inverted_sequence_number" )]
    public string InvertedSequenceNumber { get; set; } = default!;

    /// <summary>
    /// Invoice date.
    /// </summary>
    [JsonPropertyName( "date" )]
    [JsonConverter( typeof( NonIsoDateConverter ) )]
    public DateOnly Date { get; set; }

    /// <summary>
    /// Invoice due date.
    /// </summary>
    [JsonPropertyName( "due_date" )]
    [JsonConverter( typeof( NonIsoDateConverter ) )]
    public DateOnly DueDate { get; set; }

    /// <summary>
    /// Invoice purchase order reference field.
    /// </summary>
    [JsonPropertyName( "reference" )]
    public string? Reference { get; set; }

    /// <summary>
    /// Remarks, which shall be printed on the invoice.
    /// </summary>
    [JsonPropertyName( "observations" )]
    public string? Remarks { get; set; }

    /// <summary>
    /// Withholding tax percentage (%). Must be a number between 0 and 99.99.
    /// </summary>
    [Range( 0, 99.99 )]
    [JsonConverter( typeof( DecimalAsStringConverter ) )]
    [JsonPropertyName( "retention" )]
    public decimal? RetentionPercentage { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "permalink" )]
    public string Permalink { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "saft_hash" )]
    public string? SaftHash { get; set; }

    /// <summary />
    [JsonPropertyName( "sum" )]
    public decimal SumAmount { get; set; }

    /// <summary />
    [JsonPropertyName( "discount" )]
    public decimal? DiscountAmount { get; set; }

    /// <summary />
    [JsonPropertyName( "before_taxes" )]
    public decimal BeforeTaxesAmount { get; set; }

    /// <summary />
    [JsonPropertyName( "taxes" )]
    public decimal TaxesAmount { get; set; }

    /// <summary />
    [JsonPropertyName( "total" )]
    public decimal TotalAmount { get; set; }

    /// <summary />
    [JsonPropertyName( "currency" )]
    [JsonConverter( typeof( CurrencyCodeAsNameConverter ) )]
    public string CurrencyCode { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "multicurrency" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public ForeignCurrency? ForeignCurrency { get; set; }

    /// <summary />
    [JsonPropertyName( "client" )]
    public Client Client { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "items" )]
    public List<DocumentItem> Items { get; set; } = default!;
}
