namespace InvoiceXpress;

/// <summary />
[Flags]
public enum ArchiveFilter
{
    /// <summary>
    /// Return active documents.
    /// </summary>
    Active = 1,

    /// <summary>
    /// Return archived documents.
    /// </summary>
    Archived = 2,

    /// <summary>
    /// Return all documents, including archived documents.
    /// </summary>
    All = 3,
}
