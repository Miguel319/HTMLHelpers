using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using BLL;
using BOL;

namespace HTMLHelpers.Controllers
{
    public class IniciarSesionController : Controller
    {
        private UsuarioBs objBs;

        public IniciarSesionController()
        {
            objBs = new UsuarioBs();
        }

        // GET: IniciarSesion
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario usuario)
        {
            try
            {
                if (Membership.ValidateUser(usuario.Email, usuario.Contra))
                {
                    FormsAuthentication.SetAuthCookie(usuario.Email, false);
                    return RedirectToAction("Index", "Principal");
                }
                else
                {
                    TempData["Msg"] = "Error al iniciar sesión";
                    return View();
                }
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Error al iniciar sesión: " + e.Message;
                return View();
            }
        }

        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Principal");
        }
    }
}