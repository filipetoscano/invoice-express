InvoiceXpress
==========================================================================

[![CI](https://github.com/filipetoscano/invoicexpress/workflows/CI/badge.svg)](https://github.com/AutoMapper/AutoMapper/actions?query=workflow%3ACI)
[![NuGet](http://img.shields.io/nuget/vpre/InvoiceXpress.svg?label=NuGet)](https://www.nuget.org/packages/InvoiceXpress/)

.NET client for [Invoice Xpress](https://www.invoicexpress.com/), an online
invoicing software for entities based in Portugal -- certified by the 
[Portuguese Tax and Customs Authority](https://info.portaldasfinancas.gov.pt/pt/docs/Conteudos_1pagina/Pages/portuguese-tax-system.aspx).


Getting started
--------------------------------------------------------------------------

In the startup of your application, configure the DI container as follows:

```
services.AddHttpClient<InvoiceXpressClient>();

services.AddOptions<InvoiceXpressOptions>().Configure( ( opt ) =>
{
    opt.AccountName = "your account name";
    opt.ApiKey = "your api key";
} );
```

Then, inject `InvoiceXpressClient` into the caller code:

```
public class SomeController : ControllerBase
{
    private readonly InvoiceXpressClient _invexp;

    public SomeController( InvoiceXpressClient invexp )
    {
        _invexp = invexp;
    }
}
```


Installing via NuGet
--------------------------------------------------------------------------

Package is published in the [NuGet](https://www.nuget.org/packages/InvoiceXpress/)
gallery.

Using command-line:

```
dotnet add package InvoiceXpress
```

Inside Visual Studio, using Package Manager Console:

```
Install-Package InvoiceXpress
```


`invxp` cli tool
--------------------------------------------------------------------------

In addition to the .NET library, this repository also releases a cross
platform command line interface program to invoke the invoicexpress API
without programming.

```
> invxp

Execute operations on a invoicexpress account

Usage: invxp [command] [options]

Options:
  --version     Show version information.
  -?|-h|--help  Show help information.
  --debug       Trace HTTP traffic to console

Commands:
  account       Account operations
  client        Client/customer operations
  estimate      Estimate operations (quotes, proformas, fee notes)
  guide         Guide operations (delivery, shipping and return delivery notes)
  invoice       Invoice operations (invoice, receipts, debit & credit notes, etc)
  item          Item operations
  saft          SAF-T operations
  sequence      Sequence operations
  vat           VAT rate operations

Run 'invxp [command] -?|-h|--help' for more information about a command.
```

Each command has sub-commands to list, create, update, and otherwise
manipulate the corresponding entities. You can enumerate the sub-commands
with the `--help` flag, eg `invxp invoice --help`.


Running cli locally
--------------------------------------------------------------------------

.NET 6 SDK is required to compile.

In Windows:

```
> set INVEXP_API=apikey
> set INVEXP_ACCOUNT=accountname
> cd tools\InvoiceXpress.Cli
> dotnet run -- client list
```

In Linux / `bash`:

```
> export INVEXP_API=apikey
> export INVEXP_ACCOUNT=accountname
> cd tools/InvoiceXpress.Cli
> dotnet run -- client list
```


References
--------------------------------------------------------------------------

* https://www.invoicexpress.com/api-v2/documentation/getting-started
* https://nif.marcosantos.me/
* https://www.six-group.com/dam/download/financial-information/data-center/iso-currrency/lists/list_one.xml (ISO 4217 currency codes)
