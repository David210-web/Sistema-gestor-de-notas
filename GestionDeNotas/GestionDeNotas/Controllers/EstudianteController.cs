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
    [Permiso(Roles = "Alumnos")]
    public class EstudianteController : Controller
    {
        // GET: Estudiante
        public ActionResult Index()
        {
            var usuario = Session["usuario"] as Usuarios;

            ViewBag.Message = $"Bienvenido {usuario.Carnet}";
            return View();
        }

        public ActionResult Inscribir()
        {
            return View(CursoMantenimiento.GetCursos());
        }

        [HttpPost]
        public ActionResult Inscribir(string codigoCurso)
        {
            var usuario = Session["usuario"] as Usuarios;

            if (usuario == null || string.IsNullOrEmpty(codigoCurso))
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "Invalid Request");
            }

            MatriculaInscripcion.Matricularse(usuario.Carnet, codigoCurso);

            return RedirectToAction("Index", "Estudiante");
        }

        public ActionResult MisCursos()
        {
            var user = Session["usuario"] as Usuarios;
            if (user == null)
            {
                return RedirectToAction("Index", "Home"); // Redirigir si el usuario no está en sesión
            }
            var cursos = CursoMantenimiento.GetCursosByAlumno(user.Carnet);
            return View(cursos);
        }

        public ActionResult MisCalificaciones()
        {
            var user = Session["usuario"] as Usuarios;
            if (user == null)
            {
                return RedirectToAction("Index", "Home"); // Redirigir si el usuario no está en sesión
            }
            var notas = NotasMantenimiento.VerNotas(user.Carnet);
            return View(notas);
        }

    }
}