using GestaoDeVendas.Data;
using GestaoDeVendas.Models;

namespace GestaoDeVendas.Services;

public class DepartmentService
{
    private readonly GestaoDeVendasContext _context;

    public DepartmentService(GestaoDeVendasContext context)
    {
        _context = context;
    }

    public List<Department> FindAll()
    {
        return _context.Department.OrderBy(x => x.Name).ToList();
    }
}
