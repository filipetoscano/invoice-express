using InvoiceXpress.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
/// <remarks>
/// List of countries as per: https://invoicexpress.com/api-v2/documentation/appendix
/// </remarks>
[JsonConverter( typeof( EnumConverter ) )]
public enum Country
{
    /// <summary>
    /// AD, Andorra
    /// </summary>
    [EnumMember( Value = "Andorra" )]
    AD,

    /// <summary>
    /// AU, Australia
    /// </summary>
    [EnumMember( Value = "Australia" )]
    AU,

    /// <summary>
    /// CA, Canada
    /// </summary>
    [EnumMember( Value = "Canada" )]
    CA,

    /// <summary>
    /// CZ, Czechia
    /// </summary>
    [EnumMember( Value = "Czech Republic" )]
    CZ,

    /// <summary>
    /// ES, Spain
    /// </summary>
    [EnumMember( Value = "Spain" )]
    ES,

    /// <summary>
    /// IE, Ireland
    /// </summary>
    [EnumMember( Value = "Ireland" )]
    IE,

    /// <summary>
    /// GB, United Kingdom of Great Britain and Northern Ireland
    /// </summary>
    [EnumMember( Value = "UK" )]
    GB,

    /// <summary>
    /// NZ, New Zealand
    /// </summary>
    [EnumMember( Value = "New Zealand" )]
    NZ,

    /// <summary>
    /// PT, Portugal
    /// </summary>
    [EnumMember( Value = "Portugal" )]
    PT,

    /// <summary>
    /// US, United States of America
    /// </summary>
    [EnumMember( Value = "United States" )]
    US,

    /// <summary>
    /// ZA, South Africa
    /// </summary>
    [EnumMember( Value = "South Africa" )]
    ZA,
}
