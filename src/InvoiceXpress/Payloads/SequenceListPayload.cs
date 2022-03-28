using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class SequenceListPayload
{
    /// <summary />
    [JsonPropertyName( "sequences" )]
    public List<Sequence> Sequences { get; set; } = default!;
}
