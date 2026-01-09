using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConsultaARSHospital;
using ConsultaARSHospital.Models;

namespace ConsultaARSHospital.Controllers
{
    public class DoctoresController : Controller
    {
        private ConsultasHospitalEntities9 db = new ConsultasHospitalEntities9();
        internal int id_doctor;

        public string nombre { get; internal set; }

        // GET: Doctores
        public ActionResult IndexDoctores(int idHospital)
    {
        var doctoresEnHospital = db.Doctores.Where(d => d.id_hospital == idHospital).ToList();
        return View(doctoresEnHospital);
    }

        public ActionResult IndexHospitales()
        {
            // Obtén el ID del hospital de TempData si está disponible
            int? idHospital = TempData["idHospital"] as int?;

            if (idHospital != null)
            {
                // Si hay un ID de hospital en TempData, redirige al método Index con ese ID como parámetro
                return RedirectToAction("IndexHospitales", "Doctores", new { id_hospital = idHospital });
            }
            else
            {
                // Si no hay un ID de hospital en TempData, simplemente muestra la vista del índice inicial
                return View(db.Doctores.ToList());
            }
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Doctores doctor = db.Doctores.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }

            return View(doctor);
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            ViewBag.id_hospital = new SelectList(db.Hospitales, "id_hospital", "nombre_hospital");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,Email,Telefono,IdHospital")] Doctores doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctores.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("IndexDoctores");
            }

            return View(doctor);
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctores doctor = db.Doctores.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,Email,Telefono,IdHospital")] Doctores doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexDoctores");
            }
            return View(doctor);
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctores doctor = db.Doctores.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctores doctor = db.Doctores.Find(id);
            db.Doctores.Remove(doctor);
            db.SaveChanges();
            return RedirectToAction("IndexDoctores");
        }

        // Nuevas acciones agregadas

        // GET: Doctor/BuscarDisponibilidad
        public ActionResult BuscarDisponibilidad()
        {
            // Implementa la lógica para buscar la disponibilidad de los doctores
            return View();
        }

        // GET: Doctor/SeleccionarDoctor
        

        // GET: Doctor/VerificarSeguro
        public ActionResult VerificarSeguro()
        {
            // Implementa la lógica para verificar si el paciente tiene seguro
            return View();
        }

        // GET: Doctor/PagarConsulta
        public ActionResult PagarConsulta()
        {
            // Implementa la lógica para pagar la consulta
            return View();
        }

        // GET: Doctor/EnviarCorreoConfirmacion
        public ActionResult EnviarCorreoConfirmacion()
        {
            // Implementa la lógica para enviar el correo de confirmación
            return View();
        }

        // GET: Doctor/VerificarEstatusConsulta
        public ActionResult VerificarEstatusConsulta()
        {
            // Implementa la lógica para verificar el estatus de la consulta
            return View();
        }

        // GET: Doctor/SeleccionarFormaPago
        public ActionResult SeleccionarFormaPago()
        {
            // Implementa la lógica para seleccionar la forma de pago
            return View();
        }
        

        // Otras acciones
    }
    // Otras acciones como Detalles, Crear, Editar, Eliminar, etc.
}
