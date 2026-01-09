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
    public class HorariosController : Controller
    {
        private ConsultasHospitalEntities9 db = new ConsultasHospitalEntities9();

        // GET: Horarios
        public ActionResult Index()
        {
            var horarios = db.Horarios.Include(h => h.Doctores);
            return View(horarios.ToList());
        }

        // GET: Horarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horarios horarios = db.Horarios.Find(id);
            if (horarios == null)
            {
                return HttpNotFound();
            }
            return View(horarios);
        }

        // GET: Horarios/Create
        public ActionResult Create()
        {
            ViewBag.id_doctor = new SelectList(db.Doctores, "id_doctor", "nombre");
            return View();
        }

        // POST: Horarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_horario,id_doctor,dia_semana,hora_inicio,hora_fin")] Horarios horarios)
        {
            if (ModelState.IsValid)
            {
                db.Horarios.Add(horarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_doctor = new SelectList(db.Doctores, "id_doctor", "nombre", horarios.id_doctor);
            return View(horarios);
        }

        // GET: Horarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horarios horarios = db.Horarios.Find(id);
            if (horarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_doctor = new SelectList(db.Doctores, "id_doctor", "nombre", horarios.id_doctor);
            return View(horarios);
        }

        // POST: Horarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_horario,id_doctor,dia_semana,hora_inicio,hora_fin")] Horarios horarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_doctor = new SelectList(db.Doctores, "id_doctor", "nombre", horarios.id_doctor);
            return View(horarios);
        }

        // GET: Horarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horarios horarios = db.Horarios.Find(id);
            if (horarios == null)
            {
                return HttpNotFound();
            }
            return View(horarios);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Horarios horarios = db.Horarios.Find(id);
            db.Horarios.Remove(horarios);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}