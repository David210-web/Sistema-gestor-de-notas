using GestionDeNotas.Models;
using GestionDeNotas.Models.Acceso;
using GestionDeNotas.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDeNotas.Controllers
{
    [Permiso(Roles = "Profesor")]
    public class DocenteController : Controller
    {
        // GET: Docente
        public ActionResult Index()
        {
            var usuario = Session["usuario"] as Usuarios;
            ViewBag.Message = $"Bienvenido {usuario.Carnet}";
            return View();
        }

        public ActionResult MisCursos()
        {
            var usuario = Session["usuario"] as Usuarios;
            return View(CursoMantenimiento.GetCursosByTeacher(usuario.Carnet));
        }

        public ActionResult EstudiantesByCurso(string codigoCurso)
        {
            return View(AlumnoMantenimiento.GetAlumnosByCurso(codigoCurso));
        }

        public ActionResult AñadirNotas(string carnet)
        {
            ViewBag.Carnet = carnet;
            return View();
        }

        [HttpPost]
        public ActionResult AñadirNotas(Notas notas)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    NotasMantenimiento.AddNotas(notas);
                    return RedirectToAction("MisCursos");
                }
                else
                {
                    return View();
                }
            }catch (Exception ex)
            {
                return View();
            }
        }

    }
}