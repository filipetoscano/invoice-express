namespace InvoiceXpress.Rest;

/// <summary />
internal static class InvoiceEntity
{
    private static readonly string[] _propNames = new string[] {
        "invoice",
        "invoice_receipt",
        "simplified_invoice",
        "receipt",
        "credit_note",
        "debit_note",
        "vat_moss_invoice",
        "vat_moss_receipt",
        "vat_moss_credit_note",
    };


    /// <summary />
    internal static bool IsValidPropertyName( string propertyName )
    {
        return _propNames.Contains( propertyName );
    }


    /// <summary />
    internal static string ToPropertyName( InvoiceType type )
    {
        switch ( type )
        {
            case InvoiceType.Invoice:
                return "invoice";

            case InvoiceType.InvoiceReceipt:
                return "invoice_receipt";

            case InvoiceType.SimplifiedInvoice:
                return "simplified_invoice";

            case InvoiceType.Receipt:
                return "receipt";

            case InvoiceType.CreditNote:
                return "credit_note";

            case InvoiceType.DebitNote:
                return "debit_note";

            case InvoiceType.MossInvoice:
                return "vat_moss_invoice";

            case InvoiceType.MossReceipt:
                return "vat_moss_receipt";

            case InvoiceType.MossCreditNote:
                return "vat_moss_credit_note";

            default:
                throw new InvalidOperationException( $"Unsupported invoice type { type }" );
        }
    }


    /// <summary />
    internal static string ToEntityName( InvoiceType type )
    {
        return ToPropertyName( type ) + "s";
    }
}
