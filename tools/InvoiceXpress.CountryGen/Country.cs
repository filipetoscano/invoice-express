using System.Text.Json.Serialization;

namespace InvoiceXpress.CountryGen;

/// <summary />
public class Country
{
    /// <summary />
    [JsonPropertyName( "name" )]
    public CountryName Name { get; set; } = default!;

    /// <summary>
    /// 2 letter code.
    /// </summary>
    [JsonPropertyName( "cca2" )]
    public string Alpha2 { get; set; } = default!;

    /// <summary>
    /// 3 letter code.
    /// </summary>
    [JsonPropertyName( "cca3" )]
    public string Alpha3 { get; set; } = default!;

    /// <summary>
    /// Three digit country-code.
    /// </summary>
    [JsonPropertyName( "ccn3" )]
    public string CountryCode { get; set; } = default!;

    /// <summary>
    /// Flag emoji
    /// </summary>
    [JsonPropertyName( "flag" )]
    public string? Flag { get; set; }

    /// <summary>
    /// Is independent?
    /// </summary>
    [JsonPropertyName( "independent" )]
    public bool? IsIndependent { get; set; }
}


/// <summary />
public class CountryName
{
    /// <summary />
    [JsonPropertyName( "common" )]
    public string Common { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "official" )]
    public string Official { get; set; } = default!;
}