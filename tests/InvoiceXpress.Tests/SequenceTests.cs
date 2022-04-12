using System.Threading.Tasks;
using Xunit;

namespace InvoiceXpress.Tests;

/// <summary />
public class SequenceTests
{
    private readonly InvoiceXpressClient _client;


    /// <summary />
    public SequenceTests( InvoiceXpressClient client )
    {
        _client = client;
    }


    /// <summary />
    [Fact]
    public async Task List()
    {
        var res = await _client.SequenceListAsync();

        Assert.NotNull( res );
        Assert.True( res.IsSuccessful );
        Assert.NotNull( res.Result );
    }
}
