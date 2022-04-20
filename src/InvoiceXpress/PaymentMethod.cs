using System.Runtime.Serialization;

namespace InvoiceXpress;

/// <summary>
/// Method which was used to perform a payment.
/// </summary>
/// <remarks>
/// See https://invoicexpress.com/api-v2/documentation/appendix
/// </remarks>
public enum PaymentMethod
{
    /// <summary>
    /// Credit card.
    /// </summary>
    [EnumMember( Value = "CC" )]
    CreditCard,

    /// <summary>
    /// Debit card.
    /// </summary>
    [EnumMember( Value = "CD" )]
    DebitCard,

    /// <summary>
    /// Check.
    /// </summary>
    [EnumMember( Value = "CH" )]
    BankCheck,

    /// <summary>
    /// Check, or voucher.
    /// </summary>
    [EnumMember( Value = "CO" )]
    CheckOrVoucher,

    /// <summary>
    /// Current account balance compensation.
    /// </summary>
    [EnumMember( Value = "CS" )]
    BalanceCompensation,

    /// <summary />
    [EnumMember( Value = "DE" )]
    ECash,

    /// <summary>
    /// Commercial paper.
    /// </summary>
    [EnumMember( Value = "LC" )]
    CommercialPaper,

    /// <summary>
    /// Multibanco.
    /// </summary>
    [EnumMember( Value = "MB" )]
    Multibanco,

    /// <summary>
    /// Cash.
    /// </summary>
    [EnumMember( Value = "NU" )]
    Cash,

    /// <summary>
    /// Other.
    /// </summary>
    [EnumMember( Value = "OU" )]
    Other,

    /// <summary>
    /// Bank transfer.
    /// </summary>
    [EnumMember( Value = "TB" )]
    BankTransfer,

    /// <summary>
    /// Restaurant ticket.
    /// </summary>
    [EnumMember( Value = "TR" )]
    RestaurantTicket,
}
