using System.Threading.Tasks;
using Xunit;

namespace InvoiceXpress.Tests;

/// <summary />
public class ClientTests
{
    private readonly InvoiceXpressClient _client;


    /// <summary />
    public ClientTests( InvoiceXpressClient client )
    {
        _client = client;
    }


    /// <summary />
    [Fact]
    public async Task List()
    {
        var res = await _client.ClientListAsync( 1 );

        Assert.NotNull( res );
    }
}
