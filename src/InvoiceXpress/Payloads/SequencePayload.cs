using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class SequencePayload<T>
{
    /// <summary />
    [JsonPropertyName( "sequence" )]
    public T Sequence { get; set; } = default!;
}
