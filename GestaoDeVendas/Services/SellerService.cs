using GestaoDeVendas.Data;
using GestaoDeVendas.Models;

namespace GestaoDeVendas.Services;

public class SellerService
{
    private readonly GestaoDeVendasContext _context;

    public SellerService(GestaoDeVendasContext context)
    {
        _context = context;
    }

    public List<Seller> FindAll()
    {
        return _context.Seller.ToList();
    }
}
