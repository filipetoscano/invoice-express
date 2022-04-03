namespace InvoiceXpress;

/// <summary />
public static class DocumentNumberExtensions
{
    /// <summary />
    public static string? DocumentNumber( this Invoice invoice )
    {
        string prefix;

        if ( invoice.InvertedSequenceNumber == null )
            return null;

        switch ( invoice.Type )
        {
            case InvoiceType.Invoice: prefix = "FT"; break;
            case InvoiceType.InvoiceReceipt: prefix = "FR"; break;
            case InvoiceType.SimplifiedInvoice: prefix = "FS"; break;
            case InvoiceType.CreditNote: prefix = "NC"; break;
            case InvoiceType.DebitNote: prefix = "ND"; break;
            case InvoiceType.Receipt: prefix = "RG"; break;

            // TODO: What about other document types?

            default: throw new InvalidOperationException( $"Unknown document prefix for { invoice.Type }" );
        }

        return prefix + " " + invoice.InvertedSequenceNumber;
    }
}
