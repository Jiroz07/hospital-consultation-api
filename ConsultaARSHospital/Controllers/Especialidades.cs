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
    public class EspecialidadesController : Controller
    {
        private ConsultasHospitalEntities9 db = new ConsultasHospitalEntities9();

        public int id_especialidad { get; internal set; }
        public string nombre_especialidad { get; internal set; }

        // GET: Especialidades
        public ActionResult IndexEspecialidades(int idDoctor)
        {
            // Aquí debes obtener la lista de especialidades asociadas al doctor con el idDoctor proporcionado
            var especialidadesDelDoctor = db.Especialidades.Where(e => e.id_doctor == idDoctor).ToList();
            return View(especialidadesDelDoctor);
        }

        // GET: Especialidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidades especialidades = db.Especialidades.Find(id);
            if (especialidades == null)
            {
                return HttpNotFound();
            }
            return View(especialidades);
        }



        // GET: Especialidades/Create
        public ActionResult Create()
        {
            ViewBag.id_doctor = new SelectList(db.Doctores, "id_doctor", "nombre");
            return View();
        }

        // POST: Especialidades/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_especialidad,nombre_especialidad,descripcion,id_doctor")] Especialidades especialidades)
        {
            if (ModelState.IsValid)
            {
                db.Especialidades.Add(especialidades);
                db.SaveChanges();
                return RedirectToAction("IndexEspecialidades");
            }

            ViewBag.id_doctor = new SelectList(db.Doctores, "id_doctor", "nombre", especialidades.id_doctor);
            return View(especialidades);
        }

        // GET: Especialidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidades especialidades = db.Especialidades.Find(id);
            if (especialidades == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_doctor = new SelectList(db.Doctores, "id_doctor", "nombre", especialidades.id_doctor);
            return View(especialidades);
        }

        // POST: Especialidades/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_especialidad,nombre_especialidad,descripcion,id_doctor")] Especialidades especialidades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexEspecialidades");
            }
            ViewBag.id_doctor = new SelectList(db.Doctores, "id_doctor", "nombre", especialidades.id_doctor);
            return View(especialidades);
        }

        // GET: Especialidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidades especialidades = db.Especialidades.Find(id);
            if (especialidades == null)
            {
                return HttpNotFound();
            }
            return View(especialidades);
        }

        // POST: Especialidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Especialidades especialidades = db.Especialidades.Find(id);
            db.Especialidades.Remove(especialidades);
            db.SaveChanges();
            return RedirectToAction("IndexEspecialidades");
        }

        // Nuevas acciones agregadas

        // GET: Especialidades/BuscarDoctorEspecializado
        public ActionResult BuscarDoctorEspecializado()
        {
            // Implementa la lógica para buscar doctores especializados disponibles
            return View();
        }

        // GET: Especialidades/SeleccionarDoctorEspecializado
        public ActionResult SeleccionarDoctorEspecializado()
        {
            // Implementa la lógica para seleccionar un doctor especializado disponible
            return View();
        }

        // GET: Especialidades/VerificarSeguroPaciente
        public ActionResult VerificarSeguroPaciente()
        {
            // Implementa la lógica para verificar si el paciente tiene seguro
            return View();
        }

        // GET: Especialidades/VerificarEstatusConsulta
        public ActionResult VerificarEstatusConsulta()
        {
            // Implementa la lógica para verificar el estatus de la consulta
            return View();
        }

        // GET: Especialidades/EnviarCorreoConfirmacion
        public ActionResult EnviarCorreoConfirmacion()
        {
            // Implementa la lógica para enviar el correo de confirmación
            return View();
        }


        // Otras acciones como Detalles, Crear, Editar, Eliminar, etc.
    }
}