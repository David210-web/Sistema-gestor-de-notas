using GestionDeNotas.Models;
using GestionDeNotas.Models.Acceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDeNotas.Controllers
{
    [Permiso(Roles = "Administrador")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var usuarios = Session["usuario"] as Usuarios;
            ViewBag.Message = $"Bienvenido {usuarios.Carnet}";
            return View();
        }


       
    }
}
