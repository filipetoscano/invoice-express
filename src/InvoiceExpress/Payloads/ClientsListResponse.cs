using System.Text.Json.Serialization;

namespace InvoiceExpress.Payloads;

/// <summary />
public class ClientsListResponse
{
    /// <summary />
    [JsonPropertyName( "clients" )]
    public List<Client> Clients { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "pagination" )]
    public Pagination Pagination { get; set; } = default!;
}
