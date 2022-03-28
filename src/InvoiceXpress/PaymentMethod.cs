using InvoiceExpress.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace InvoiceExpress;

/// <summary>
/// Method which was used to perform a payment.
/// </summary>
/// <remarks>
/// See https://invoicexpress.com/api-v2/documentation/appendix
/// </remarks>
[JsonConverter( typeof( EnumConverter ) )]
public enum PaymentMethod
{
    /// <summary />
    [EnumMember( Value = "CC" )]
    CreditCard,

    /// <summary />
    [EnumMember( Value = "CD" )]
    DebitCard,

    /// <summary />
    [EnumMember( Value = "CH" )]
    BankCheck,

    /// <summary />
    [EnumMember( Value = "CO" )]
    CheckOrVoucher,

    /// <summary />
    [EnumMember( Value = "CS" )]
    BalanceCompensation,

    /// <summary />
    [EnumMember( Value = "DE" )]
    ECash,

    /// <summary />
    [EnumMember( Value = "LC" )]
    CommercialPaper,

    /// <summary />
    [EnumMember( Value = "MB" )]
    Multibanco,

    /// <summary />
    [EnumMember( Value = "NU" )]
    Cash,

    /// <summary />
    [EnumMember( Value = "OU" )]
    Other,

    /// <summary />
    [EnumMember( Value = "TB" )]
    BankTransfer,

    /// <summary />
    [EnumMember( Value = "TR" )]
    RestaurantTicket,
}
