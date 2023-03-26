using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestaoDeVendas.Models;

namespace GestaoDeVendas.Data
{
    public class GestaoDeVendasContext : DbContext
    {
        public GestaoDeVendasContext (DbContextOptions<GestaoDeVendasContext> options)
            : base(options)
        {
        }

        public DbSet<GestaoDeVendas.Models.Department> Department { get; set; } = default!;
    }
}
