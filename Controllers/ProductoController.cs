using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjercicioMVC.Data;
using EjercicioMVC.Data.Repository;
using EjercicioMVC.Data.Repository.Interfaces;
using EjercicioMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EjercicioMVC.Controllers
{
    public class ProductoController : Controller
    {

        private readonly ProductosContext _context;
        private readonly IProductoRepository _productoRepository;
        /* public ProductoController(ProductosContext context)
         {
             _context = context;
         }*/
        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public async Task<IActionResult> Index()
        {
            //var productos = GetData();
            //var productos = await _context.Productos.ToListAsync();
            var productos = await _productoRepository.GetAll();
            return View(productos);
        }

        //GET :localhost/puerto/Producto/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: localhost/puerto/Producto/Create
        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                /*producto.FechaDeAlta = DateTime.Now;
                _context.Add(producto);
                await _context.SaveChangesAsync();*/
                var result = await _productoRepository.Create(producto);
                if (result < 0)
                {
                    ViewBag.ErrorMessage = "Error al guardar los datos";
                    return View(producto);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ErrorMessage = "Modelo no valido";
            return View(producto);
        }
        //GET :localhost/puerto/Producto/Edit/2
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
                return NotFound();

            var producto = await _productoRepository.GetById(id);
            if (producto == null)
                return NotFound();
            return View(producto);
        }

        //POST: localhost:puerto/Producto/Edit2
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if (id != producto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                /* _context.Update(producto);
                await _context.SaveChangesAsync();*/
                var result = await _productoRepository.Update(producto);
                if (result < 0)
                {
                    ViewBag.ErrorMessage = "Error al guardar los datos";
                    return View(producto);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ErrorMessage = "Modelo no valido";

            return View(producto);

        }

        //GET :localhost/puerto/Producto/Delete/2
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();
            //var producto = await _context.Productos.FindAsync(id);
            var producto = await _productoRepository.GetById(id);
            if (producto == null)
                return NotFound();

            return View(producto);
        }

        //POST :localhost/puerto/Producto/Delete/2
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            //var producto = await _context.Productos.FindAsync(id);
            //_context.Productos.Remove(producto);
            //await _context.SaveChangesAsync();
            var result = await _productoRepository.DeleteById(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.ErrorMessage = "Error al borrar el producto";
                return View();
            }
        }
        public List<Producto> GetData()
        {
            List<Producto> productos = new List<Producto>();
            productos.Add(new Producto { Id = 1, Nombre = "Cafe", Descripcion = "Cafe en grano", Precio = 201.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1) });
            productos.Add(new Producto { Id = 2, Nombre = "Cafe colombiano ", Descripcion = "Cafe en grano colombiano", Precio = 230.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1) });
            productos.Add(new Producto { Id = 3, Nombre = "Cafe sumatra", Descripcion = "Cafe en grano sumatra", Precio = 250.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1) });
            productos.Add(new Producto { Id = 4, Nombre = "Cafe molido", Descripcion = "Cafe molido fino ", Precio = 300.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1) });
            productos.Add(new Producto { Id = 5, Nombre = "Cafe molido", Descripcion = "Cafe molido medio", Precio = 400.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1) });
            productos.Add(new Producto { Id = 6, Nombre = "Leche de Almendras", Descripcion = "Leche de Almendras", Precio = 50.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1) });
            productos.Add(new Producto { Id = 7, Nombre = "Leche", Descripcion = "Leche natural de vaca", Precio = 40.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1) });
            productos.Add(new Producto { Id = 8, Nombre = "Botella de agua", Descripcion = "Botella de agua de 500 ml", Precio = 10.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1) });

            return productos;
        }
    }
}