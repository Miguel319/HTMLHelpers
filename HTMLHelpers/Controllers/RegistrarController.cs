using BLL;
using BOL;
using System.Web.Mvc;

namespace HTMLHelpers.Controllers
{
    public class RegistrarController : Controller
    {
        private UsuarioBs objBs;

        public RegistrarController()
        {
            objBs = new UsuarioBs();
        }

        // GET: Registrar
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario usuario)
        {
                if (ModelState.IsValid)
                {
                     objBs.Agregar(usuario);
                    return RedirectToAction("Index", "Principal");
                }
            
                return View();
        }
    }
}