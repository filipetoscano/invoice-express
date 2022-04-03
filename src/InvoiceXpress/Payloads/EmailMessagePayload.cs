using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class EmailMessagePayload
{
    /// <summary />
    [JsonPropertyName( "message" )]
    public EmailMessageEx EmailMessage { get; set; } = default!;
}
