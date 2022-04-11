using System.Threading.Tasks;
using Xunit;

namespace InvoiceXpress.Tests;

/// <summary />
public class GuideTests
{
    private readonly InvoiceXpressClient _client;


    /// <summary />
    public GuideTests( InvoiceXpressClient client )
    {
        _client = client;
    }


    /// <summary />
    [Fact]
    public async Task List()
    {
        var res = await _client.GuideListAsync( new GuideSearch(), 1 );

        Assert.NotNull( res );
    }
}
