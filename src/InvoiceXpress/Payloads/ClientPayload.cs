using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class ClientPayload
{
    /// <summary />
    [JsonPropertyName( "client" )]
    public Client Client { get; set; } = default!;
}
