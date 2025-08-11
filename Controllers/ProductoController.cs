using Microsoft.AspNetCore.Mvc;
using programacion1_tarea3.Models;
using System.Collections.Generic;
using System.Linq;

namespace programacion1_tarea3.Controllers
{
    public class ProductoController : Controller
    {
        private List<Producto> ObtenerProductos()
        {
            return new List<Producto>
            {
                new Producto { Nombre = "Collar para perro", Precio = 25.50m },
                new Producto { Nombre = "Juguete para gato", Precio = 15.00m },
                new Producto { Nombre = "Cama para mascota", Precio = 80.00m },
                new Producto { Nombre = "Comida para perro 5kg", Precio = 120.00m }
            };
        }

        public IActionResult Seleccionar()
        {
            return View(ObtenerProductos());
        }

        [HttpPost]
        public IActionResult Seleccionar(List<Producto> productos)
        {
            var seleccionados = productos.Where(p => p.Seleccionado).ToList();
            return RedirectToAction("Confirmacion", new { seleccion = string.Join(",", seleccionados.Select(p => p.Nombre)) });
        }

        public IActionResult Confirmacion(string seleccion)
        {
            var productos = string.IsNullOrEmpty(seleccion) ? new List<string>() : seleccion.Split(',').ToList();
            return View(productos);
        }
    }
}
