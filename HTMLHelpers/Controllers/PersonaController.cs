using System;
using System.Threading.Tasks;
using BLL;
using BOL;
using System.Web.Mvc;

namespace HTMLHelpers.Controllers
{
    public class PersonaController : Controller
    {
        private PersonaBs objBs;
        private GeneroBs objBsGenero;

        public PersonaController()
        {
            objBs = new PersonaBs();
            objBsGenero = new GeneroBs();
        }

        // GET: Persona
        public async Task<ActionResult> Index()
        {
            return View(await objBs.Todos());
        }

        [HttpGet]
        public async Task<ActionResult> Agregar()
        {
            ViewBag.GeneroId = new SelectList(await objBsGenero.Todos(), "Id", "Descripcion");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Agregar(Persona persona)
        {
            if (ModelState.IsValid)
            {
                await objBs.Agregar(persona);
                return RedirectToAction("Index", "Persona");
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Editar(int id)
        {
            ViewBag.GeneroId = new SelectList(await objBsGenero.Todos(), "Id", "Descripcion");

            var persona = await objBs.ObtenerPorId(id);
            return View(persona);
        }

        [HttpPost]
        public async Task<ActionResult> Editar(Persona persona)
        {
            if (ModelState.IsValid)
            {
                await objBs.Actualizar(persona);
                return RedirectToAction("Index", "Persona");
            }
            return View(persona);
        }

        [HttpGet]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                await objBs.Eliminar(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Error"] = "Error al eliminar persona. Inténtelo de nuevo";
                return RedirectToAction("Index", "Persona");
            }
        }
    }
}