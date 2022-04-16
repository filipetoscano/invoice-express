using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;

namespace InvoiceXpress.Json;

/// <summary />
public static class JsonEnum<T>
    where T : notnull
{
    private static readonly Lazy<Dictionary<T, string>> map = new Lazy<Dictionary<T, string>>( () => MapBuild() );


    /// <summary />
    public static string ToValue( T value )
    {
        return map.Value[ value ];
    }


    /// <summary />
    public static T FromValue( string value )
    {
        /*
         * If no match is found from `SingleOrDefault`, the default for
         * `KeyValuePair` will be returned -- but since that's a struct,
         * it will get initialized with the default values for the given
         * data-types.
         * 
         * And since .Key is an enum, the default value will be the 1st
         * value in the enum! If we want to check that the KVP didn't
         * exist in the collection, we can check if the value is null!
         */
        var kv = map.Value.SingleOrDefault( x => x.Value == value );

        if ( kv.Value == null )
            throw new JsonException( $"Unable to map value '{ value }' to enum '{ typeof( T ) }'" );

        return kv.Key;
    }


    /// <summary />
    private static Dictionary<T, string> MapBuild()
    {
        var type = typeof( T );
        var map = new Dictionary<T, string>();

        foreach ( T m in Enum.GetValues( type ) )
        {
            var name = m.ToString()!;

            var member = type.GetMember( name )[ 0 ];
            var attr = member.GetCustomAttribute<EnumMemberAttribute>();

            if ( attr != null )
                map.Add( m, attr.Value! );
            else
                map.Add( m, name );
        }

        return map;
    }
}
