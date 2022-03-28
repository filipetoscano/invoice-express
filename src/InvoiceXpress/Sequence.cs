using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class SequenceRef
{
    /// <summary />
    [JsonPropertyName( "id" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public int? Id { get; set; }

    /// <summary>
    /// Sequence code.
    /// </summary>
    [JsonPropertyName( "serie" )]
    public string Code { get; set; } = default!;

    /// <summary>
    /// Is the sequence the current sequence, to which documents shall be
    /// emitted to?
    /// </summary>
    [JsonPropertyName( "default_sequence" )]
    [JsonConverter( typeof( BooleanAsNumberConverter ) )]
    public bool IsDefaultSequence { get; set; }
}


/// <summary />
public class Sequence : SequenceRef
{
    /// <summary />
    [JsonPropertyName( "current_invoice_number" )]
    public int InvoiceCounter { get; set; }

    /// <summary />
    [JsonPropertyName( "current_invoice_receipt_number" )]
    public int InvoiceReceiptCounter { get; set; }

    /// <summary />
    [JsonPropertyName( "current_simplified_invoice_number" )]
    public int SimplifiedInvoiceCounter { get; set; }

    /// <summary />
    [JsonPropertyName( "current_credit_note_number" )]
    public int CreditNoteCounter { get; set; }

    /// <summary />
    [JsonPropertyName( "current_debit_note_number" )]
    public int DebitNoteCounter { get; set; }

    /// <summary />
    [JsonPropertyName( "current_receipt_number" )]
    public int ReceiptCounter { get; set; }

    /// <summary />
    [JsonPropertyName( "current_shipping_number" )]
    public int ShippingCounter { get; set; }

    /// <summary />
    [JsonPropertyName( "current_transport_number" )]
    public int TransportCounter { get; set; }

    /// <summary />
    [JsonPropertyName( "current_devolution_number" )]
    public int ReturnsCounter { get; set; }

    /// <summary />
    [JsonPropertyName( "current_proforma_number" )]
    public int ProformaCounter { get; set; }

    /// <summary />
    [JsonPropertyName( "current_quote_number" )]
    public int QuoteCounter { get; set; }

    /// <summary />
    [JsonPropertyName( "current_fees_note_number" )]
    public int FeesNoteCounter { get; set; }

    /// <summary />
    [JsonPropertyName( "current_purchase_order_number" )]
    public int PurchaseOrderCounter { get; set; }

    /// <summary />
    [JsonPropertyName( "current_vat_moss_invoice_number" )]
    public int MossInvoiceCounter { get; set; }

    /// <summary />
    [JsonPropertyName( "current_vat_moss_credit_note_number" )]
    public int MossCreditNoteCounter { get; set; }

    /// <summary />
    [JsonPropertyName( "current_vat_moss_receipt_number" )]
    public int MossReceiptCounter { get; set; }
}
