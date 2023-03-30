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

        public DbSet<Department> Department { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
        public DbSet<Seller> Seller { get; set; }
    }
}
