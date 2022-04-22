namespace InvoiceXpress;

/// <summary />
public class EmailMessage
{
    /// <summary>
    /// Email address to which the email will be sent.
    /// </summary>
    public string To { get; set; } = default!;

    /// <summary>
    /// Subject of the email.
    /// </summary>
    public string Subject { get; set; } = default!;

    /// <summary>
    /// Text to appear in the email body.
    /// </summary>
    public string Body { get; set; } = default!;

    /// <summary>
    /// Carbon-copy email field.
    /// </summary>
    public string? CC { get; set; }

    /// <summary>
    /// Blind carbon-copy email field.
    /// </summary>
    public string? BCC { get; set; }


    /// <summary>
    /// Saves email address as the default email address of the client.
    /// </summary>
    public bool SaveEmailAsDefault { get; set; }

    /// <summary>
    /// Send email with company logotype.
    /// </summary>
    /// <remarks>
    /// Option is only available in some plans, see https://www.invoicexpress.com/en/pricing
    /// for the 'Your logo on documents' feature. If the account does not have
    /// a configured logo, a value of <see cref="true" /> is ignored.
    /// </remarks>
    public bool IncludeLogo { get; set; }
}
