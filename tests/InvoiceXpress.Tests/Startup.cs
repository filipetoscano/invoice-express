using Microsoft.Extensions.DependencyInjection;
using System;

namespace InvoiceXpress.Tests;

/// <summary />
public class Startup
{
    /// <summary />
    public void ConfigureServices( IServiceCollection services )
    {
        services.AddHttpClient<InvoiceXpressClient>();
        services.AddSingleton<InvoiceXpressClient>();

        services.AddOptions<InvoiceXpressOptions>().Configure( ( opt ) =>
        {
            var apiKey = Environment.GetEnvironmentVariable( "INVXP_APIKEY" );
            var account = Environment.GetEnvironmentVariable( "INVXP_ACCOUNT" );

            if ( apiKey == null )
                throw new ApplicationException( "Environment variable 'INVXP_APIKEY' not set" );

            if ( account == null )
                throw new ApplicationException( "Environment variable 'INVXP_ACCOUNT' not set" );

            opt.AccountName = account;
            opt.ApiKey = apiKey;
        } );

        services.AddSingleton<ScenarioConfig>( new ScenarioConfig()
        {
            EmailTo = "filipe.toscano@halyards.app",
        } );
    }
}
