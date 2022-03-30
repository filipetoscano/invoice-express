using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class EstimateListPayload
{
    /// <summary />
    [JsonPropertyName( "estimates" )]
    public List<Estimate> Estimates { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "pagination" )]
    public Pagination Pagination { get; set; } = default!;
}
