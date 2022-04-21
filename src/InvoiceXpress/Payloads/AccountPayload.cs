using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class AccountPayload
{
    /// <summary />
    [JsonPropertyName( "account" )]
    public Account Account { get; set; } = default!;
}
