using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjercicioMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EjercicioMVC.Data
{
    public class ProductosContext : DbContext
    {
        public ProductosContext(DbContextOptions<ProductosContext> options)
        : base(options)
        {

        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


    }
}