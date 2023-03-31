using GestaoDeVendas.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeVendas.Controllers;
public class SellersController : Controller
{
    private readonly SellerService _context;
    public SellersController(SellerService context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var list = _context.FindAll();
        return View(list);
    }
}
