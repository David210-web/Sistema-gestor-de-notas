using GestionDeNotas.Models;
using GestionDeNotas.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDeNotas.Controllers
{
    public class AlumnosController : Controller
    {
        // GET: Alumnos
        public ActionResult Index()
        {
            return View(AlumnoMantenimiento.GetAlumnos());
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(string carnet)
        {
            return View(AlumnoMantenimiento.GetAlumno(carnet));
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alumnos/Create
        [HttpPost]
        public ActionResult Create(Alumnos alumnos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AlumnoMantenimiento.AddAlumnos(alumnos);
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

        // GET: Alumnos/Edit/5
        public ActionResult Edit(string carnet)
        {
            return View(AlumnoMantenimiento.GetAlumno(carnet));
        }

        // POST: Alumnos/Edit/5
        [HttpPost]
        public ActionResult Edit(Alumnos alumnos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AlumnoMantenimiento.UpdateAlumnos(alumnos);
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

        // GET: Alumnos/Delete/5
        public ActionResult Delete(string carnet)
        {
            return View(AlumnoMantenimiento.GetAlumno(carnet));
        }

        // POST: Alumnos/Delete/5
        [HttpPost]
        public ActionResult Delete(string carnet,FormCollection from)
        {
            try
            {
                AlumnoMantenimiento.DeleteAlumnos(carnet);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       

        
    }
}
