using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestorHorariov2._0.Models;
using GestorHorariov2._0.Filters;

namespace GestorHorariov2._0.Controllers
{
    public class LoginController : Controller
    {
        private Usuario usuario = new Usuario();
        // GET: Login
        [NoLogin]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ValidaR(string Usuario, string Password)
        {
            var rm = usuario.ValidarLogin(Usuario, Password);
            if (rm.response)
            {
                rm.href = Url.Content("~/Default");
            }
            return Json(rm);
        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/Login");
        }
    }
}