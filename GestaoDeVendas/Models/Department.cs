namespace GestaoDeVendas.Models;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

    //Construct
    public Department() { }

    public Department(string name)
    {
        Name = name;
    }

    //Function
    public void AddSeller(Seller seller)
    {
        Sellers.Add(seller);
    }
    public double TotalSales(DateTime initial, DateTime final)
    {
        return Sellers.Sum(seller => seller.TotalSales(initial, final));
    }
}
