using InvoiceXpress.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class InvoiceData
{
    /// <summary />
    [JsonPropertyName( "id" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public int? Id { get; set; }

    /// <summary />
    public InvoiceType Type { get; set; }

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
    [JsonPropertyName( "client" )]
    public ClientRef Client { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "items" )]
    public List<DocumentItemRef> Items { get; set; } = default!;


    /// <summary />
    [JsonPropertyName( "tax_exemption" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public string? TaxExemption { get; set; }

    /// <summary>
    /// The id of the document associated with this document. This option
    /// is only available for credit and debit notes.
    /// </summary>
    [JsonPropertyName( "owner_invoice_id" )]
    public int? ParentDocumentId { get; set; }
}
