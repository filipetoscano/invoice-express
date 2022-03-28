InvoiceXpress
==========================================================================

C# client for [Invoice Xpress](https://www.invoicexpress.com/), an online
invoicing software for entities based in Portugal -- certified by the 
[Portuguese Tax and Customs Authority](https://info.portaldasfinancas.gov.pt/pt/docs/Conteudos_1pagina/Pages/portuguese-tax-system.aspx).


Status / Roadmap
--------------------------------------------------------------------------

This library is currently under development! It is not currently usable
for production use.

The roadmap is currently as follows:

* Invoice methods
* Quote methods
* CI/CD using github actions
* Error handling / throwing
* Logging support
* Polly support


Installing via NuGet
--------------------------------------------------------------------------

Using command-line:

```
dotnet add package InvoiceXpress
```

Inside Visual Studio, using Package Manager Console:

```
Install-Package InvoiceXpress
```


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
* https://github.com/actions/setup-dotnet
* https://docs.github.com/en/actions/automating-builds-and-tests/building-and-testing-net
