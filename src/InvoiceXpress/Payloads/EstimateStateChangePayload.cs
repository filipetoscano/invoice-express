using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class EstimateStateChangePayload
{
    /// <summary />
    [JsonPropertyName( "quote" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public EstimateStateChange? Quote { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "proforma" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public EstimateStateChange? Proforma { get; set; } = default!;

    /// <summary />
    [JsonPropertyName( "fees_note" )]
    [JsonIgnore( Condition = JsonIgnoreCondition.WhenWritingNull )]
    public EstimateStateChange? FeeNote { get; set; } = default!;


    /// <summary />
    internal static EstimateStateChangePayload From( EstimateType type, EstimateStateChange data )
    {
        if ( type == EstimateType.Quote )
            return new EstimateStateChangePayload() { Quote = data };

        if ( type == EstimateType.Proforma )
            return new EstimateStateChangePayload() { Proforma = data };

        if ( type == EstimateType.FeeNote )
            return new EstimateStateChangePayload() { FeeNote = data };

        throw new InvalidOperationException( $"Unsupported estimate type { type }" );
    }
}
