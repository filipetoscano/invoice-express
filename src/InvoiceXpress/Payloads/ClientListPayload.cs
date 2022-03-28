using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class ClientListPayload
{
    /// <summary />
    [JsonPropertyName( "clients" )]
    public List<Client> Clients { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "pagination" )]
    public Pagination Pagination { get; set; } = default!;
}
