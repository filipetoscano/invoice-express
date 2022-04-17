namespace InvoiceXpress.Cli.Faker;

/// <summary />
internal interface IFaker<T>
{
    /// <summary />
    T Generate();
}
