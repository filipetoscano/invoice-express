using System.Text.Json.Serialization;

namespace InvoiceExpress.Payloads;

/// <summary />
public class Pagination
{
    /// <summary>
    /// Number of total records.
    /// </summary>
    [JsonPropertyName( "total_entries" )]
    public int EntryCount { get; set; }

    /// <summary>
    /// Index of current page.
    /// </summary>
    [JsonPropertyName( "current_page" )]
    public int Page { get; set; }

    /// <summary>
    /// Number of pages of <see cref="PageSize" />
    /// </summary>
    [JsonPropertyName( "total_pages" )]
    public int PageCount { get; set; }

    /// <summary>
    /// Numbers of records per page.
    /// </summary>
    [JsonPropertyName( "per_page" )]
    public int PageSize { get; set; }
}
