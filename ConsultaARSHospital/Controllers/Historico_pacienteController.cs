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
    public class Historico_pacienteController : Controller
    {
        private ConsultasHospitalEntities9 db = new ConsultasHospitalEntities9();

        // GET: Historico_paciente
        public ActionResult Index()
        {
            var historico_paciente = db.Historico_paciente.Include(h => h.Estatus).Include(h => h.Resultado_factura);
            return View(historico_paciente.ToList());
        }

        // GET: Historico_paciente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historico_paciente historico_paciente = db.Historico_paciente.Find(id);
            if (historico_paciente == null)
            {
                return HttpNotFound();
            }
            return View(historico_paciente);
        }

        // GET: Historico_paciente/Create
        public ActionResult Create()
        {
            ViewBag.id_estatus = new SelectList(db.Estatus, "id_estatus", "nombre_estatus");
            ViewBag.id_resultado_factura = new SelectList(db.Resultado_factura, "id_resultado_factura", "id_resultado_factura");
            return View();
        }

        // POST: Historico_paciente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_historico_paciente,id_resultado_factura,id_estatus,fecha_cambio_estatus")] Historico_paciente historico_paciente)
        {
            if (ModelState.IsValid)
            {
                db.Historico_paciente.Add(historico_paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_estatus = new SelectList(db.Estatus, "id_estatus", "nombre_estatus", historico_paciente.id_estatus);
            ViewBag.id_resultado_factura = new SelectList(db.Resultado_factura, "id_resultado_factura", "id_resultado_factura", historico_paciente.id_resultado_factura);
            return View(historico_paciente);
        }

        // GET: Historico_paciente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historico_paciente historico_paciente = db.Historico_paciente.Find(id);
            if (historico_paciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_estatus = new SelectList(db.Estatus, "id_estatus", "nombre_estatus", historico_paciente.id_estatus);
            ViewBag.id_resultado_factura = new SelectList(db.Resultado_factura, "id_resultado_factura", "id_resultado_factura", historico_paciente.id_resultado_factura);
            return View(historico_paciente);
        }

        // POST: Historico_paciente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_historico_paciente,id_resultado_factura,id_estatus,fecha_cambio_estatus")] Historico_paciente historico_paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historico_paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_estatus = new SelectList(db.Estatus, "id_estatus", "nombre_estatus", historico_paciente.id_estatus);
            ViewBag.id_resultado_factura = new SelectList(db.Resultado_factura, "id_resultado_factura", "id_resultado_factura", historico_paciente.id_resultado_factura);
            return View(historico_paciente);
        }

        // GET: Historico_paciente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historico_paciente historico_paciente = db.Historico_paciente.Find(id);
            if (historico_paciente == null)
            {
                return HttpNotFound();
            }
            return View(historico_paciente);
        }

        // POST: Historico_paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Historico_paciente historico_paciente = db.Historico_paciente.Find(id);
            db.Historico_paciente.Remove(historico_paciente);
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