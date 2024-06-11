using GestionDeNotas.Models;
using GestionDeNotas.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDeNotas.Controllers
{
    public class ProfesoresController : Controller
    {
        // GET: Profesores
        public ActionResult Index()
        {

            return View(DocenteMantenimiento.GetProfesores());
        }

        // GET: Profesores/Details/5
        public ActionResult Details(string carnet)
        {
            return View(DocenteMantenimiento.GetProfesor(carnet));
        }

        // GET: Profesores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profesores/Create
        [HttpPost]
        public ActionResult Create(Profesor teacher)
        {
            try
            {
               if(ModelState.IsValid)
               {
                     DocenteMantenimiento.AddProfesor(teacher);
                     return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

                
                
                // TODO: Add insert logic here
            }
            catch
            {
                return View();
            }
        }

        // GET: Profesores/Edit/5
        public ActionResult Edit(string carnet)
        {
            return View(DocenteMantenimiento.GetProfesor(carnet));
        }

        // POST: Profesores/Edit/5
        [HttpPost]
        public ActionResult Edit(Profesor teacher)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DocenteMantenimiento.UpdateProfesor(teacher);
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

        // GET: Profesores/Delete/5
        public ActionResult Delete(string carnet)
        {
            return View(DocenteMantenimiento.GetProfesor(carnet));
        }

        // POST: Profesores/Delete/5
        [HttpPost]
        public ActionResult Delete(string carnet,FormCollection form)
        {
            try
            {
                DocenteMantenimiento.DeleteProfesor(carnet);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
