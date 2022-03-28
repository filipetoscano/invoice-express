namespace InvoiceXpress;

/// <summary />
public class InvoiceXpressOptions
{
    /// <summary>
    /// Name of the account.
    /// </summary>
    /// <remarks>
    /// Represents the host-name of the server where the API is hosted.
    /// </remarks>
    public string AccountName { get; set; } = default!;

    /// <summary>
    /// Key for API access.
    /// </summary>
    public string ApiKey { get; set; } = default!;
}
