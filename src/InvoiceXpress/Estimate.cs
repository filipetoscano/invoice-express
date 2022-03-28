using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class Estimate
{
    /// <summary />
    [JsonPropertyName( "id" )]
    public int? Id { get; set; }
}
