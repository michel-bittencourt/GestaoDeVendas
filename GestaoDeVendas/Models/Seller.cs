namespace GestaoDeVendas.Models;

public class Seller
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public double BaseSalary { get; set; }
    public Department Department { get; set; }
    public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();

    //Constructs
    public Seller() { }

    public Seller(string name, string email, DateTime birthDate, double baseSalary, Department department)
    {
        Name = name;
        Email = email;
        BirthDate = birthDate;
        BaseSalary = baseSalary;
        Department = department;
    }

    //Functions
    public void AddSales(SalesRecord record)
    {
        SalesRecords.Add(record);
    }
    public void RemoveSales(SalesRecord record)
    {
        SalesRecords.Remove(record);
    }
    public double TotalSales(DateTime initial, DateTime final)
    {
        return SalesRecords.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
    }
}
