namespace InvoiceXpress;

/// <summary />
public class Pagination
{
    /// <summary>
    /// Number of total records.
    /// </summary>
    public int EntryCount { get; set; }

    /// <summary>
    /// Index of current page.
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// Number of pages of <see cref="PageSize" />
    /// </summary>
    public int PageCount { get; set; }

    /// <summary>
    /// Numbers of records per page.
    /// </summary>
    public int PageSize { get; set; }
}
