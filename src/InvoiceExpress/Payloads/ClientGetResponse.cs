using System.Text.Json.Serialization;

namespace InvoiceExpress.Payloads;

/// <summary />
public class ClientGetResponse
{
    /// <summary />
    [JsonPropertyName( "client" )]
    public Client Client { get; set; } = default!;
}
