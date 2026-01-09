using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConsultaARSHospital;

namespace ConsultaARSHospital.Controllers
{
    public class SegurosController : Controller
    {
        private ConsultasHospitalEntities9 db = new ConsultasHospitalEntities9();

        // GET: Seguros
        public ActionResult IndexSeguros()
        {
            return View(db.Seguros.ToList());
        }

        // GET: Seguros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seguros seguros = db.Seguros.Find(id);
            if (seguros == null)
            {
                return HttpNotFound();
            }
            return View(seguros);
        }

        // GET: Seguros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seguros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_seguro,nombre_seguro,tipo_cobertura")] Seguros seguros)
        {
            if (ModelState.IsValid)
            {
                db.Seguros.Add(seguros);
                db.SaveChanges();
                return RedirectToAction("IndexSeguros");
            }

            return View(seguros);
        }

        // GET: Seguros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seguros seguros = db.Seguros.Find(id);
            if (seguros == null)
            {
                return HttpNotFound();
            }
            return View(seguros);
        }

        // POST: Seguros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_seguro,nombre_seguro,tipo_cobertura")] Seguros seguros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seguros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexSeguros");
            }
            return View(seguros);
        }

        // GET: Seguros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seguros seguros = db.Seguros.Find(id);
            if (seguros == null)
            {
                return HttpNotFound();
            }
            return View(seguros);
        }

        // POST: Seguros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seguros seguros = db.Seguros.Find(id);
            db.Seguros.Remove(seguros);
            db.SaveChanges();
            return RedirectToAction("IndexSeguros");
        }

        // Nuevas acciones agregadas

        // GET: Seguros/VerificarCobertura
        public ActionResult VerificarCobertura()
        {
            // Implementa la lógica para verificar la cobertura del seguro
            return View();
        }

        // GET: Seguros/SeleccionarSeguro
        public ActionResult SeleccionarSeguro()
        {
            // Implementa la lógica para seleccionar un seguro
            return View();
        }

        // Otras acciones como Detalles, Crear, Editar, Eliminar, etc.
    }
}