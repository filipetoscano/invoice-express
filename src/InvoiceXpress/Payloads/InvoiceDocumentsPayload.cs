using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class InvoiceDocumentsPayload
{
    /// <summary />
    [JsonPropertyName( "documents" )]
    public List<Invoice> Documents { get; set; } = default!;
}
