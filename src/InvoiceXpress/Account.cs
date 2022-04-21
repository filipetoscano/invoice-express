using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class Account
{
    /// <summary />
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public int? Id { get; set; }

    /// <summary />
    [JsonPropertyName( "organization_name" )]
    public string Name { get; set; } = default!;

    /// <summary>
    /// Portuguese Tax Number, NIF.
    /// </summary>
    [JsonPropertyName( "fiscal_id" )]
    public string TaxNumber { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "address" )]
    public string? Address { get; set; } = default!;

    /// <summary>
    /// Postal code, in dddd-ddd format.
    /// </summary>
    [JsonPropertyName( "postal_code" )]
    public string? PostalCode { get; set; } = default!;

    /// <summary>
    /// City name.
    /// </summary>
    [JsonPropertyName( "city" )]
    public string? City { get; set; } = default!;

    /// <summary>
    /// Country.
    /// </summary>
    [JsonPropertyName( "tax_country" )]
    [JsonConverter( typeof( CountryCodeAsNameConverter ) )]
    public string? Country { get; set; }

    /// <summary>
    /// Email address, which shall be displayed to customers on the
    /// issued documents (invoices, et al).
    /// </summary>
    [JsonPropertyName( "email" )]
    public string Email { get; set; } = default!;

    /// <summary>
    /// Account state.
    /// </summary>
    [JsonPropertyName( "state" )]
    public string? State { get; set; }

    /// <summary>
    /// Account state.
    /// </summary>
    [JsonPropertyName( "at_configured" )]
    public bool? IsTaxAuthorityConfigured { get; set; }

    /// <summary>
    /// Indicates whether the account is a trial account
    /// </summary>
    [JsonPropertyName( "trial" )]
    public bool? IsTrial { get; set; }
}
