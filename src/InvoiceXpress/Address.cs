using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class Address
{
    /// <summary />
    [JsonPropertyName( "detail" )]
    public string AddressLines { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "postal_code" )]
    public string PostalCode { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "city" )]
    public string City { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "country" )]
    [JsonConverter( typeof( CountryCodeAsNameConverter ) )]
    public string Country { get; set; } = default!;
}
