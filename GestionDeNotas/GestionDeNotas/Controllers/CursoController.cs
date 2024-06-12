using GestionDeNotas.Models;
using GestionDeNotas.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDeNotas.Controllers
{
    public class CursoController : Controller
    {
        // GET: Curso
        public ActionResult Index()
        {
            return View(CursoMantenimiento.GetCursos());
        }

        // GET: Curso/Details/5
        public ActionResult Details(string codigo)
        {
            return View(CursoMantenimiento.GetCurso(codigo));
        }

        // GET: Curso/Create
        public ActionResult Create()
        {
            var docentes = DocenteMantenimiento.GetProfesores();
            var materias = MateriaMantenimiento.GetMaterias();
            ViewBag.DocentesList = new SelectList(docentes, "Carnet", "Carnet");
            ViewBag.CursoList = new SelectList(materias, "CodigoMateria", "CodigoMateria");
            return View();
        }

        // POST: Curso/Create
        [HttpPost]
        public ActionResult Create(Curso curso)
        {
            try
            {
                
                if(ModelState.IsValid)
                {
                    CursoMantenimiento.AddCurso(curso);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Curso/Edit/5
        public ActionResult Edit(string codigo)
        {
            return View(CursoMantenimiento.GetCurso(codigo));
        }

        // POST: Curso/Edit/5
        [HttpPost]
        public ActionResult Edit(Curso curso)
        {
            try
            {   if(ModelState.IsValid)
                {
                    CursoMantenimiento.UpdateCurso(curso);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
                // TODO: Add update logic here

            }
            catch
            {
                return View();
            }
        }

        // GET: Curso/Delete/5
        public ActionResult Delete(string codigo)
        {
            return View(CursoMantenimiento.GetCurso(codigo));
        }

        // POST: Curso/Delete/5
        [HttpPost]
        public ActionResult Delete(string codigo,FormCollection formCollection)
        {
            try
            {
                // TODO: Add delete logic here
                CursoMantenimiento.DeleteCurso(codigo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
