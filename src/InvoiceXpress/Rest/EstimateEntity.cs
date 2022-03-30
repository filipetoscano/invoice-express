namespace InvoiceXpress.Rest;

/// <summary />
internal static class EstimateEntity
{
    private static readonly string[] _propNames = new string[] { "quote", "proforma", "fees_note" };


    /// <summary />
    internal static bool IsValidPropertyName( string propertyName )
    {
        return _propNames.Contains( propertyName );
    }


    /// <summary />
    internal static string ToElementName( EstimateType type )
    {
        if ( type == EstimateType.Quote )
            return "quote";

        if ( type == EstimateType.Proforma )
            return "proforma";

        if ( type == EstimateType.FeeNote )
            return "fees_note";

        throw new InvalidOperationException( $"Unsupported estimate type { type }" );
    }


    /// <summary />
    internal static string ToEntityName( EstimateType type )
    {
        return ToElementName( type ) + "s";
    }
}
