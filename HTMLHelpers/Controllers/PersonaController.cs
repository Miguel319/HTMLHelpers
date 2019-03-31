using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HTMLHelpers.Controllers
{
    public class PersonaController : Controller
    {
        private PersonaBs objBs;
        private GeneroBs objBsGenero;
        private string[] arr;

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

            List<string> hobbies = new List<string>();

            hobbies.Add("Ver TV");
            hobbies.Add("Programar");
            hobbies.Add("Leer");
            hobbies.Add("Jugar videojuegos");

            ViewBag.Hobbies = hobbies;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Agregar(Persona persona, FormCollection c)
        {
            if (ModelState.IsValid)
            {
                string hobbies = c["Hobbys"];

                persona.Hobbys = hobbies;

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
        public async Task<ActionResult> Editar(Persona persona, string lista)
        {
            if (ModelState.IsValid)
            {
                string[] array = lista.Split(',');
                
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