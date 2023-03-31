using GestaoDeVendas.Models;
using GestaoDeVendas.Models.ViewModels;
using GestaoDeVendas.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeVendas.Controllers;
public class SellersController : Controller
{
    private readonly SellerService _SellerService;
    private readonly DepartmentService _DepartmentService;
    public SellersController(SellerService sellerService, DepartmentService departmentService)
    {
        _SellerService = sellerService;
        _DepartmentService = departmentService;
    }

    public IActionResult Index()
    {
        var list = _SellerService.FindAll();
        return View(list);
    }

    //Esse metodo abre o formulario para cadastrar o vendedor
    public IActionResult Create()
    {
        var departments = _DepartmentService.FindAll();
        var viewModel = new SellerFormViewModel { Departments = departments };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Seller seller)
    {
        _SellerService.Insert(seller);
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Delete(int? id)
    {
        if(id == null)
        {
            return NotFound();
        }
        var obj = _SellerService.FindById(id.Value);

        if(obj == null)
        {
            return NotFound();
        }
        return View(obj);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        _SellerService.Remove(id);
        return RedirectToAction(nameof(Index));
    }
}
