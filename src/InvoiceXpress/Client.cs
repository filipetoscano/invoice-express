using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class ClientRef
{
    /// <inheritdoc />
    [JsonPropertyName( "code" )]
    public string Code { get; set; } = default!;

    /// <inheritdoc />
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;
}


/// <summary />
public class Client
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

    /// <inheritdoc />
    [JsonPropertyName( "code" )]
    public string Code { get; set; } = default!;

    /// <inheritdoc />
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;

    /// <summary>
    /// Client language. May be en, pt or es; defaults to the account language.
    /// </summary>
    /// <remarks>
    /// In UI, field is set in 'Billing preferences > Send Options'.
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
    [JsonConverter( typeof( CountryCodeAsNameConverter ) )]
    public string? Country { get; set; }

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
    /// Note: Not being returned by API
    //[JsonPropertyName( "mobile" )]
    //public string? Mobile { get; set; }

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
    public string? Remarks { get; set; }

    /// <summary />
    /// <remarks>
    /// In UI, field is set in 'Billing preferences > Send Options'.
    /// </remarks>
    [JsonPropertyName( "send_options" )]
    [JsonConverter( typeof( EnumAsNumberConverter ) )]
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
    [JsonConverter( typeof( PhoneAsNumberConverter ) )]
    public string? Mobile { get; set; }
}
