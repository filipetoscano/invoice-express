namespace InvoiceXpress.Cli.Faker;

/// <summary />
public class InvoiceFaker : BaseFaker, IFaker<InvoiceData>
{
    /// <summary />
    public InvoiceFaker()
    {
    }


    /// <summary />
    public InvoiceData Generate()
    {
        var today = DateOnly.FromDateTime( DateTime.Now );
        var due = today.AddDays( 15 );

        var obj = new InvoiceData();
        obj.Type = InvoiceType.Invoice;
        obj.Date = today;
        obj.DueDate = due;


        /*
         * 
         */
        obj.Client = new ClientRef();
        obj.Client.Code = "CODE";
        obj.Client.Name = "NAME";


        /*
         * 
         */
        var item = new DocumentItemRef();
        item.Code = "CODE";
        item.Quantity = 1;
        item.UnitPrice = 1;
        item.VatRate = new VatRateRef();
        item.VatRate.Code = "VAT23";

        obj.Items = new List<DocumentItemRef>();
        obj.Items.Add( item );

        return obj;
    }
}
