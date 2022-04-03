using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class EmailMessageEx
{
    /// <summary />
    [JsonPropertyName( "client" )]
    public EmailClient Client { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "subject" )]
    public string Subject { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "body" )]
    public string Body { get; set; } = default!;

    /// <summary>
    /// Carbon-copy email field.
    /// </summary>
    [JsonPropertyName( "cc" )]
    public string? CC { get; set; }

    /// <summary>
    /// Blind carbon-copy email field.
    /// </summary>
    [JsonPropertyName( "bcc" )]
    public string? BCC { get; set; }

    /// <summary>
    /// Send email with company logotype.
    /// </summary>
    /// <remarks>
    /// Option is only available in some plans, see https://www.invoicexpress.com/en/pricing
    /// for the 'Your logo on documents' feature. If the account does not have
    /// a configured logo, a value of <see cref="true" /> is ignored.
    /// </remarks>
    [JsonPropertyName( "logo" )]
    [JsonConverter( typeof( BooleanAsStringConverter ) )]
    public bool IncludeLogo { get; set; }
}


/// <summary />
public class EmailClient
{
    /// <summary>
    /// Email address.
    /// </summary>
    [JsonPropertyName( "email" )]
    public string Email { get; set; } = default!;

    /// <summary>
    /// Saves email address as the default email address of the client.
    /// </summary>
    [JsonPropertyName( "save" )]
    [JsonConverter( typeof( BooleanAsStringConverter ) )]
    public bool SaveEmailAsDefault { get; set; }
}
