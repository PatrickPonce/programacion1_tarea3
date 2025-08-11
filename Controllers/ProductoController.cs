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
                new Producto { Nombre = "Collar para perro", Precio = 25.50m, ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRbJegywO2EXTj-C1c_NzSpAJPTLTt5CEMD2A&s" },
                new Producto { Nombre = "Juguete para gato", Precio = 15.00m, ImagenUrl = "https://guaw.com/30188-home_default/juguete-surtido-ferplast-5017-para-gato.jpg" },
                new Producto { Nombre = "Cama para mascota", Precio = 80.00m, ImagenUrl = "https://www.clubdeperrosygatos.cl/wp-content/uploads/2024/05/cama-ortopedica.webp" },
                new Producto { Nombre = "Comida para perro 5kg", Precio = 120.00m, ImagenUrl = "https://www.acerix.com.uy/imgs/productos/productos35_55040.jpg" }
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
