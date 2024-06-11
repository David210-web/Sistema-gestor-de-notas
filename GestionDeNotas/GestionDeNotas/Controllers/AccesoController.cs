using GestionDeNotas.Models;
using GestionDeNotas.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace GestionDeNotas.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuarios user)
        {
            int result = UsuarioMantenimiento.Logearse(user);

            if(result != 0)
            {
                Session["usuario"] = user;
                string rol = UsuarioMantenimiento.ObtenerRol(user.Carnet);
                switch(rol)
                {
                    case "Administrador":
                            return RedirectToAction("Index", "Admin");
                    case "Profesor":
                        return RedirectToAction("Index","Docente");
                    case "Alumnos":
                        return RedirectToAction("Index","Estudiante");
                    default:
                        return View();
                }
            }
            else
            {
                ViewData["message"] = "Usuario no encontrado";
                return View();
            }
        }

        public ActionResult CerrarSesion()
        {
            Session["usuario"] = null;
            return RedirectToAction("Login", "Acceso");
        }

        public ActionResult NoAutorizado()
        {
            return View();
        }
    }
}