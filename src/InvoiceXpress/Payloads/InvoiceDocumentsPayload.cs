using System.Text.Json.Serialization;

namespace InvoiceExpress.Payloads;

/// <summary />
public class InvoiceDocumentsPayload
{
    /// <summary />
    [JsonPropertyName( "documents" )]
    public List<Invoice> Documents { get; set; } = default!;
}
