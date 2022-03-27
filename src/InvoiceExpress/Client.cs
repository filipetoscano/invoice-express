using InvoiceExpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceExpress;

/// <summary />
public class ClientRef
{
    /// <summary>
    /// Client code, your specific code for the client.
    /// </summary>
    [JsonPropertyName( "code" )]
    public string Code { get; set; } = default!;

    /// <summary>
    /// Client name, normally used for a company name.
    /// </summary>
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;
}


/// <summary />
public class Client : ClientRef
{
    /// <summary>
    /// Client identifier.
    /// </summary>
    /// <remarks>
    /// Field may not be set during create, will be available when
    /// fetching the entity (through get or list).
    /// </remarks>
    [JsonPropertyName( "id" )]
    public int? Id { get; set; }

    /// <summary>
    /// Client language. May be en, pt or es; defaults to the account language.
    /// </summary>
    /// <remarks>
    /// In UI, field is set in 'Billing preferences > Language'.
    /// </remarks>
    [JsonPropertyName( "language" )]
    public string? Language { get; set; }

    /// <summary>
    /// Client email address. Must be a valid email address.
    /// </summary>
    [JsonPropertyName( "email" )]
    public string? Email { get; set; }

    /// <summary>
    /// Client company address.
    /// </summary>
    [JsonPropertyName( "address" )]
    public string? Address { get; set; }

    /// <summary>
    /// Client’s city.
    /// </summary>
    [JsonPropertyName( "city" )]
    public string? City { get; set; }

    /// <summary>
    /// Postal code.
    /// </summary>
    [JsonPropertyName( "postal_code" )]
    public string? PostalCode { get; set; }

    /// <summary>
    /// (Fiscal) country.
    /// </summary>
    [JsonPropertyName( "country" )]
    public Country? Country { get; set; }

    /// <summary />
    [JsonPropertyName( "fiscal_id" )]
    public string? TaxNumber { get; set; }

    /// <summary />
    [JsonPropertyName( "website" )]
    public string? Website { get; set; }

    /// <summary />
    [JsonPropertyName( "phone" )]
    public string? Phone { get; set; }

    /// <summary />
    [JsonPropertyName( "mobile" )]
    public string? Mobile { get; set; }

    /// <summary />
    [JsonPropertyName( "fax" )]
    public string? Fax { get; set; }

    /// <summary />
    [JsonPropertyName( "preferred_contact" )]
    public ClientContact? PreferredContact { get; set; }

    /// <summary />
    /// <remarks>
    /// In UI, field is set in 'Billing preferences > Remarks'.
    /// </remarks>
    [JsonPropertyName( "observations" )]
    public string? Observations { get; set; }

    /// <summary />
    /// <remarks>
    /// In UI, field is set in 'Billing preferences > Send Options'.
    /// </remarks>
    [JsonPropertyName( "send_options" )]
    public SendOptions? DocumentSendOptions { get; set; }

    /// <summary />
    /// <remarks>
    /// In UI, field is set in 'Billing preferences > Due in'.
    /// </remarks>
    [JsonPropertyName( "payment_days" )]
    public int PaymentDays { get; set; }

    /// <summary />
    /// <remarks>
    /// In UI, field is set in 'Billing preferences > Tax exemption reason'.
    /// </remarks>
    [JsonPropertyName( "tax_exemption_code" )]
    public string TaxExemptionCode { get; set; } = default!;
}


/// <summary />
public class ClientContact
{
    /// <summary />
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "email" )]
    public string? Email { get; set; }

    /// <summary />
    [JsonPropertyName( "phone" )]
    public string? Phone { get; set; }

    /// <summary />
    [JsonPropertyName( "mobile" )]
    public int? Mobile { get; set; }
}


/// <summary />
[JsonConverter( typeof( EnumAsNumberConverter ) )]
public enum SendOptions
{
    /// <summary>
    /// Original only.
    /// </summary>
    OriginalOnly = 1,

    /// <summary>
    /// Original, and duplicate.
    /// </summary>
    Duplicate = 2,

    /// <summary>
    /// Original, duplicate and triplicate.
    /// </summary>
    Triplicate = 3,
}
