using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InvoiceExpress;

/// <summary />
public class Invoice
{
    /// <summary />
    [JsonPropertyName( "proprietary_uid" )]
    public string? ExternalId { get; set; }

    /// <summary />
    [JsonPropertyName( "id" )]
    public string? Id { get; set; }

    /// <summary>
    /// Id of the document sequence for this invoice. If not specified, the default
    /// sequence will be used.
    /// </summary>
    [JsonPropertyName( "sequence_id" )]
    public string? SequenceId { get; set; }

    /// <summary>
    /// Portuguese IVA exemption code. Required for portuguese accounts on invoices with 
    /// IVA exempt items (0%).
    /// </summary>
    /// <remarks>
    /// Refer to the Appendix for the complete list of “IVA Exemption Codes”.
    /// </remarks>
    [JsonPropertyName( "tax_exemption" )]
    public string? TaxExemption { get; set; }

    /// <summary>
    /// Used when updating a document and removing all tax exempt items. The code
    /// M00 means 'Without tax exemption'.
    /// </summary>
    [JsonPropertyName( "tax_exemption_reason" )]
    public string? TaxExemptionReason { get; set; }

    /// <summary />
    //public Client Client { get; set; } = default!;

    /// <summary>
    /// Invoice date.
    /// </summary>
    [JsonPropertyName( "due_date" )]
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
    /// Invoice observations, which shall be printed on the invoice.
    /// </summary>
    [JsonPropertyName( "observations" )]
    public string? Observations { get; set; }

    /// <summary>
    /// The (owner) invoice associated to this document. This option is only
    /// available for credit_notes or debit_notes. You can also send the (owner)
    /// guide id when creating an invoice to associate an invoice to a guide.
    /// </summary>
    [JsonPropertyName( "owner_invoice_id" )]
    public long? OwnerInvoiceId { get; set; }

    /// <summary>
    /// Withholding tax percentage (%). Must be a number
    /// between 0 and 99.99.
    /// </summary>
    [Range( 0, 99.99 )]
    [JsonConverter( typeof( DecimalAsStringConverter ) )]
    [JsonPropertyName( "retention" )]
    public decimal? Retention { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "permalink" )]
    public string Permalink { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "saft_hash" )]
    public string? SaftHash { get; set; }

    /// <summary />
    [JsonPropertyName( "sum" )]
    public decimal Sum { get; set; }

    /// <summary />
    [JsonPropertyName( "discount" )]
    public decimal Discount { get; set; }

    /// <summary />
    [JsonPropertyName( "before_taxes" )]
    public decimal BeforeTaxes { get; set; }

    /// <summary />
    [JsonPropertyName( "taxes" )]
    public decimal Taxes { get; set; }

    /// <summary />
    [JsonPropertyName( "total" )]
    public decimal Total { get; set; }

    /// <summary />
    /// <remarks>
    /// See https://www.iso.org/iso-4217-currency-codes.html
    /// </remarks>
    [JsonPropertyName( "currency_code" )]
    public string? CurrencyCode { get; set; }

    /// <summary />
    [JsonPropertyName( "rate" )]
    public decimal? CurrencyExchangeRate { get; set; }
}


/// <summary />
public class InvoiceX
{
    /// <summary />
    [JsonPropertyName( "status" )]
    public string Status { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "archived" )]
    public bool IsArchived { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "sequence_number" )]
    public string SequenceNumber { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "inverted_sequence_number" )]
    public string InvertedSequenceNumber { get; set; } = default!;
}


/// <summary />
public class Multibanco
{
    /// <summary />
    [JsonPropertyName( "entity" )]
    public string Entity { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "reference" )]
    public string Reference { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "value" )]
    public decimal Value { get; set; }
}
