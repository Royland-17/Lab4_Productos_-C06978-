using Lab4_Productos__C06978_.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_Productos__C06978_.Controllers
{

    public class ProductosController : Controller
    {
       
        public IActionResult Index()
        {
            var productos = ProductoRepositorio.ObtenerTodos();
            return View(productos);
        }

     
        public IActionResult Detalles(int id)
        {
            var producto = ProductoRepositorio.ObtenerPorId(id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        
        public IActionResult Crear() => View();

        
        [HttpPost]
        public IActionResult Crear(Producto p)
        {
            if (ModelState.IsValid)
            {
                ProductoRepositorio.Agregar(p);
                return RedirectToAction(nameof(Index));
            }
            return View(p);
        }

        
        public IActionResult Editar(int id)
        {
            var producto = ProductoRepositorio.ObtenerPorId(id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        [HttpPost]
        public IActionResult Editar(Producto p)
        {
            if (ModelState.IsValid)
            {
                ProductoRepositorio.Actualizar(p);
                return RedirectToAction(nameof(Index));
            }
            return View(p);
        }

        
        public IActionResult Eliminar(int id)
        {
            var producto = ProductoRepositorio.ObtenerPorId(id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        [HttpPost]
        public IActionResult ConfirmarEliminar(int id)
        {
            ProductoRepositorio.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}