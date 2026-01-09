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
    public class HospitalesController : Controller
    {
        private ConsultasHospitalEntities9 db = new ConsultasHospitalEntities9();

        public int id_hospital { get; internal set; }
        public string nombre_hospital { get; internal set; }

        // GET: Hospitales
        public ActionResult IndexHospitales()
        {
            var hospitales = db.Hospitales.ToList();
            return View(hospitales);
        }

        // POST: Hospitales/SelectHospital
        [HttpPost]
        public ActionResult SelectHospital(int idHospital)
        {
            return RedirectToAction("IndexHospitales", "Doctores", new { idHospital = idHospital });
        }

        // GET: Hospitales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospitales hospitales = db.Hospitales.Find(id);
            if (hospitales == null)
            {
                return HttpNotFound();
            }
            return View(hospitales);
        }

        // GET: Hospitales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hospitales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_hospital,nombre_hospital,direccion,telefono")] Hospitales hospitales)
        {
            if (ModelState.IsValid)
            {
                db.Hospitales.Add(hospitales);
                db.SaveChanges();
                return RedirectToAction("Crear");
            }

            return View(hospitales);
        }

        // GET: Hospitales/Edit/5
        public ActionResult Edit(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospitales hospitales = db.Hospitales.Find(id);
            if (hospitales == null)
            {
                return HttpNotFound();
            }
            return View(hospitales);
        }

        // POST: Hospitales/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_hospital,nombre_hospital,direccion,telefono")] Hospitales hospitales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospitales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexHospitales");
            }
            return View(hospitales);
        }

        // GET: Hospitales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospitales hospitales = db.Hospitales.Find(id);
            if (hospitales == null)
            {
                return HttpNotFound();
            }
            return View(hospitales);
        }

        // POST: Hospitales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hospitales hospitales = db.Hospitales.Find(id);
            db.Hospitales.Remove(hospitales);
            db.SaveChanges();
            return RedirectToAction("IndexHospitales");
        }

        // Nuevas acciones agregadas

        // GET: Hospitales/BuscarDoctorEspecializado
        public ActionResult BuscarDoctorEspecializado()
        {
            // Implementa la lógica para buscar doctores especializados disponibles
            return View();
        }

        // GET: Hospitales/SeleccionarDoctorEspecializado
        public ActionResult SeleccionarDoctorEspecializado()
        {
            // Implementa la lógica para seleccionar un doctor especializado disponible
            return View();
        }

        // GET: Hospitales/VerificarSeguroPaciente
        public ActionResult VerificarSeguroPaciente()
        {
            // Implementa la lógica para verificar si el paciente tiene seguro
            return View();
        }

        // GET: Hospitales/VerificarEstatusConsulta
        public ActionResult VerificarEstatusConsulta()
        {
            // Implementa la lógica para verificar el estatus de la consulta
            return View();
        }

        // GET: Hospitales/EnviarCorreoConfirmacion
        public ActionResult EnviarCorreoConfirmacion()
        {
            // Implementa la lógica para enviar el correo de confirmación
            return View();
        }

        public ActionResult SeleccionarDoctores(int id)
        {
            return RedirectToAction("IndexDoctores", "Doctores", new { idHospital = id });
        }

        // Otras acciones
    }
    // Otras acciones como Detalles, Crear, Editar, Eliminar, etc.
}
