using System.Text.Json.Serialization;

namespace InvoiceExpress;

/// <summary />
public class Sequence
{
    /// <summary />
    [JsonPropertyName( "id" )]
    public long Id { get; set; }

    /// <summary />
    [JsonPropertyName( "series" )]
    public string Series { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "default" )]
    [JsonConverter( typeof( BooleanAsNumberConverter ) )]
    public bool IsDefaultSequence { get; set; }
}
