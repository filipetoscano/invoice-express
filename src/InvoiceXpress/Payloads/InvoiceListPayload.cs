using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class InvoiceListPayload
{
    /// <summary />
    [JsonPropertyName( "invoices" )]
    public List<Estimate> Invoices { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "pagination" )]
    public Pagination Pagination { get; set; } = default!;
}
