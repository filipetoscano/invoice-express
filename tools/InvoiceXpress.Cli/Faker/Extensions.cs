namespace InvoiceXpress.Cli.Faker;

/// <summary />
internal static class Extensions
{
    /// <summary />
    internal static int WeighedSum( this string value, int[] weights )
    {
        #region Validations

        if ( weights.Length == 0 )
            throw new ArgumentOutOfRangeException( nameof( weights ), $"Multiplier vector should be non-zero in size." );

        if ( value.Length < weights.Length )
            throw new ArgumentOutOfRangeException( nameof( value ), $"Expected string with at least { weights.Length } chars, had only { value.Length }." );

        #endregion

        var sum = 0;

        for ( var i = 0; i < weights.Length; i++ )
        {
            var n = int.Parse( value[ i ].ToString() );
            sum += n * weights[ i ];
        }

        return sum;
    }
}
