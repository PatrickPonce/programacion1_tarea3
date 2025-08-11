using Microsoft.AspNetCore.Mvc;
using programacion1_tarea3.Models;

namespace programacion1_tarea3.Controllers
{
    public class MascotaController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Confirmacion", mascota);
            }
            return View(mascota);
        }

        public IActionResult Confirmacion(Mascota mascota)
        {
            return View(mascota);
        }
    }
}
