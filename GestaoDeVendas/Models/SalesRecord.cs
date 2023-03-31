using GestaoDeVendas.Models.Enums;

namespace GestaoDeVendas.Models;

public class SalesRecord
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public double Amount { get; set; }
    public SaleStatus Status { get; set; }
    public Seller Saller { get; set; }

    //Constructs
    public SalesRecord() { }

    public SalesRecord(DateTime date, double amount, SaleStatus status, Seller saller)
    {
        Date = date;
        Amount = amount;
        Status = status;
        Saller = saller;
    }
}
