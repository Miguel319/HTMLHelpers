using System;
using System.Web.Mvc;
using BLL;
using BOL;

namespace HTMLHelpers.Controllers
{
    public class SignInController : Controller
    {
        private UsuarioBs usuarioBs;

        public SignInController()
        {
            usuarioBs = new UsuarioBs();
        }
        
        // GET: SignIn
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuarioBs.Agregar(usuario);
                    return RedirectToAction("Index", "Principal");
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Error al registrar usuario: " + e.Message;
                return RedirectToAction("Index", "Registrar");

            }
        }
    }
}