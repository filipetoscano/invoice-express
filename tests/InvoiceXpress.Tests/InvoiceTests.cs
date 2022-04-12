using System.Threading.Tasks;
using Xunit;

namespace InvoiceXpress.Tests;

/// <summary />
public class InvoiceTests
{
    private readonly InvoiceXpressClient _client;


    /// <summary />
    public InvoiceTests( InvoiceXpressClient client )
    {
        _client = client;
    }


    /// <summary />
    [Fact]
    public async Task List()
    {
        var res = await _client.InvoiceListAsync( new InvoiceSearch(), 1 );

        Assert.NotNull( res );
        Assert.True( res.IsSuccessful );
        Assert.NotNull( res.Result );
    }
}
