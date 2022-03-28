using System.Text.Json.Serialization;

namespace InvoiceXpress.CountryGen;

/// <summary />
public class Country
{
    /// <summary />
    [JsonPropertyName( "name" )]
    public string Name { get; set; } = default!;

    /// <summary>
    /// 2 letter code.
    /// </summary>
    [JsonPropertyName( "alpha-2" )]
    public string Alpha2 { get; set; } = default!;

    /// <summary>
    /// 3 letter code.
    /// </summary>
    [JsonPropertyName( "alpha-3" )]
    public string Alpha3 { get; set; } = default!;

    /// <summary>
    /// Three digit country-code.
    /// </summary>
    [JsonPropertyName( "country-code" )]
    public string CountryCode { get; set; } = default!;

    /// <summary>
    /// Region
    /// </summary>
    [JsonPropertyName( "region" )]
    public string Region { get; set; } = default!;

    /// <summary>
    /// Region
    /// </summary>
    [JsonPropertyName( "sub-region" )]
    public string SubRegion { get; set; } = default!;
}
