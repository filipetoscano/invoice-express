using InvoiceXpress.Json;
using System.Text.Json.Serialization;

namespace InvoiceXpress;

/// <summary />
public class Estimate
{
    /// <summary />
    [JsonPropertyName( "id" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public int? Id { get; set; }

    /// <summary />
    [JsonPropertyName( "status" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public EstimateState? State { get; set; }

    /// <summary />
    [JsonPropertyName( "archived" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public bool? IsArchived { get; set; }

    /// <summary />
    [JsonPropertyName( "type" )]
    public EstimateType Type { get; set; }

    /// <summary />
    [JsonPropertyName( "sequence_number" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public string? SequenceNumber { get; set; }

    /// <summary />
    [JsonPropertyName( "date" )]
    [JsonConverter( typeof( NonIsoDateConverter ) )]
    public DateOnly Date { get; set; }

    /// <summary />
    [JsonPropertyName( "due_date" )]
    [JsonConverter( typeof( NonIsoDateConverter ) )]
    public DateOnly DueDate { get; set; }

    /// <summary />
    [JsonPropertyName( "reference" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public string? Reference { get; set; }
}
