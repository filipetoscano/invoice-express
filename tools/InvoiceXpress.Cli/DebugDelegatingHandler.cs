using Microsoft.Extensions.Options;

namespace InvoiceXpress.Cli;

/// <summary />
public class DebugDelegatingHandlerOptions
{
    /// <summary />
    public bool Enabled { get; set; }
}


/// <summary />
public class DebugDelegatingHandler : DelegatingHandler
{
    private readonly DebugDelegatingHandlerOptions _options;

    /// <summary />
    public DebugDelegatingHandler( IOptions<DebugDelegatingHandlerOptions> options )
    {
        _options = options.Value;
    }


    /// <summary />
    protected override async Task<HttpResponseMessage> SendAsync( HttpRequestMessage request, CancellationToken cancellationToken )
    {
        /*
         * Request
         */
        if ( _options.Enabled == true )
        {
            Console.WriteLine( ">> {0} {1}", request.Method, request.RequestUri );
            Console.WriteLine( request.ToString() );
            if ( request.Content != null )
                Console.WriteLine( await request.Content.ReadAsStringAsync() );
            Console.WriteLine();
        }


        /*
         * Invoke
         */
        var response = await base.SendAsync( request, cancellationToken );


        /*
         * Response
         */
        if ( _options.Enabled == true )
        {
            Console.WriteLine( "<< {0} {1} {2}", (int) response.StatusCode, response.StatusCode, response.ReasonPhrase );
            Console.WriteLine( response.ToString() );

            if ( response.Content != null )
                Console.WriteLine( await response.Content.ReadAsStringAsync() );
            Console.WriteLine();
        }

        return response;
    }
}
