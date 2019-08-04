using LPA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPA.Context
{
    public class ProductosDbContext : DbContext
    {
        public ProductosDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
    }
}
