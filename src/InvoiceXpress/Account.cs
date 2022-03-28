using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class Account
{
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
    /// Email address, which shall be displayed to customers on the
    /// issued documents (invoices, et al).
    /// </summary>
    [JsonPropertyName( "email" )]
    public string Email { get; set; } = default!;
}
