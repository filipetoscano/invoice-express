namespace InvoiceXpress.Rest;

/// <summary />
internal static class GuideEntity
{
    private static readonly string[] _propNames = new string[] { "transport", "shipping", "devolution" };


    /// <summary />
    internal static bool IsValidPropertyName( string propertyName )
    {
        return _propNames.Contains( propertyName );
    }


    /// <summary />
    internal static string ToPropertyName( GuideType type )
    {
        if ( type == GuideType.DeliveryNote )
            return "transport";

        if ( type == GuideType.ShippingNote )
            return "shipping";

        if ( type == GuideType.ReturnDeliveryNote )
            return "devolution";

        throw new InvalidOperationException( $"Unsupported guide type { type }" );
    }


    /// <summary />
    internal static string ToEntityName( GuideType type )
    {
        return ToPropertyName( type ) + "s";
    }
}
