using GestionDeNotas.Models;
using GestionDeNotas.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionDeNotas.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult Index()
        {
            return View(MateriaMantenimiento.GetMaterias());
        }

        // GET: Materia/Details/5
        public ActionResult Details(string codigo)
        {
            return View(MateriaMantenimiento.GetMateria(codigo));
        }

        // GET: Materia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Materia/Create
        [HttpPost]
        public ActionResult Create(Materia materia)
        {
            try
            {
               if(ModelState.IsValid)
               {
                    MateriaMantenimiento.AddMateria(materia);
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

        // GET: Materia/Edit/5
        public ActionResult Edit(string codigo)
        {
            return View(MateriaMantenimiento.GetMateria(codigo));
        }

        // POST: Materia/Edit/5
        [HttpPost]
        public ActionResult Edit(Materia materia)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    MateriaMantenimiento.UpdateMateria(materia);
                    return RedirectToAction("Index");
                }else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Materia/Delete/5
        public ActionResult Delete(string codigo)
        {
            return View(MateriaMantenimiento.GetMateria(codigo));
        }

        // POST: Materia/Delete/5
        [HttpPost]
        public ActionResult Delete(string codigo, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                MateriaMantenimiento.DeleteMateria(codigo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
