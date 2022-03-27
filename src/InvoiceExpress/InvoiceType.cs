using InvoiceExpress.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace InvoiceExpress;

/// <summary />
[JsonConverter( typeof( EnumConverter ) )]
public enum InvoiceType
{
    /// <summary>
    /// Invoice.
    /// </summary>
    [EnumMember( Value = "Invoice" )]
    Invoice,

    /// <summary>
    /// Combined invoice and receipt.
    /// </summary>
    [EnumMember( Value = "InvoiceReceipt" )]
    InvoiceReceipt,

    /// <summary>
    /// Simplified invoice (and receipt).
    /// </summary>
    [EnumMember( Value = "SimplifiedInvoice" )]
    SimplifiedInvoice,

    /// <summary>
    /// Credit note.
    /// </summary>
    [EnumMember( Value = "CreditNote" )]
    CreditNote,

    /// <summary>
    /// Debit note.
    /// </summary>
    [EnumMember( Value = "DebitNote" )]
    DebitNote,

    /// <summary>
    /// Receipt.
    /// </summary>
    [EnumMember( Value = "Receipt" )]
    Receipt,

    /// <summary>
    /// Cash invoice.
    /// </summary>
    [EnumMember( Value = "CashInvoice" )]
    CashInvoice,

    /// <summary>
    /// MOSS (Mini One Stop Shop) invoice.
    /// </summary>
    [EnumMember( Value = "VatMossInvoice" )]
    MossInvoice,

    /// <summary>
    /// MOSS (Mini One Stop Shop) receipt.
    /// </summary>
    [EnumMember( Value = "VatMossReceipt" )]
    MossReceipt,

    /// <summary>
    /// MOSS (Mini One Stop Shop) credit note.
    /// </summary>
    [EnumMember( Value = "VatMossCreditNote" )]
    MossCreditNote,
}
