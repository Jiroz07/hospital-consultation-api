using ConsultaARSHospital.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ConsultaARSHospital.Controllers
{
    public class HomeController : Controller
    {


        private ConsultasHospitalEntities9 db = new ConsultasHospitalEntities9();

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Agendar Cita";

            // Obtener los datos necesarios para la vista
            ViewBag.Hospitales = db.Hospitales?.ToList();
            ViewBag.Doctores = db.Doctores?.ToList();
            ViewBag.Especialidades = db.Especialidades?.ToList();
            ViewBag.Forma_de_pago = db.Forma_de_pago?.ToList();
            ViewBag.Horarios = db.Horarios?.ToList();

            // Establecer el hospital seleccionado por defecto (por ejemplo, el primer hospital en la lista)
            int hospitalSeleccionado = 0;
            int.TryParse(Request.Form["hospital"], out hospitalSeleccionado);
            ViewBag.HospitalSeleccionado = hospitalSeleccionado;

            


            return View();
        }

        public ActionResult CrearPacientes(string nombreHospital, string nombreDoctor, string nombreEspecialidad)
        {
            ViewBag.NombreHospitalSeleccionado = nombreHospital;
            ViewBag.NombreDoctorSeleccionado = nombreDoctor;
            ViewBag.NombreEspecialidadSeleccionada = nombreEspecialidad;

            var seguros = db.Seguros.ToList();
            var horarios = db.Horarios.ToList();

            // Pasar los datos a la vista utilizando ViewBag
            ViewBag.Seguros = new SelectList(seguros, "id_seguro", "nombre_seguro");
            ViewBag.Horarios = new SelectList(horarios, "id_horario", "dia_semana");

            // Retornar la vista
            return View();
        }


        // POST: /Home/CrearPacientes
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearPacientes(Pacientes pacientes)
        {
            if (ModelState.IsValid)
            {
                // Guardar la cita del paciente en la base de datos
                db.Pacientes.Add(pacientes);
                db.SaveChanges();

                // Obtener el horario de la cita
                var horario = db.Horarios.FirstOrDefault(h => h.id_horario == pacientes.id_horario);
                var seguros = db.Seguros.FirstOrDefault(h => h.id_seguro == pacientes.id_seguro);
                // Mensaje de éxito para mostrar en la vista
                TempData["Mensaje"] = $"Su cita ha sido enviada en {pacientes.nombre} {pacientes.apellido}. Se le estará confirmando su cita a través de su correo {pacientes.email} tomando en cuenta el horario de la {horario.dia_semana} y si el seguro de {seguros.nombre_seguro} cubre o no.Gracias por confiar en nosotros.";

                return RedirectToAction("Index");
            }

            // Si hay errores de validación, regresar a la vista CrearPacientes con el modelo de paciente
            return View(pacientes);
        }






        // Otras acciones del controlador...



        [HttpPost]
        public ActionResult GuardarPacientes(FormCollection form)
        {
            // Aquí puedes manejar la lógica para guardar los datos del paciente en la base de datos
            // Por ejemplo, puedes recuperar los datos del formulario utilizando el parámetro FormCollection

            // Después de guardar el paciente, podrías redirigir a alguna otra acción, como por ejemplo la acción Index

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            var hospitales = ObtenerHospitalesDesdeLaBaseDeDatos();
            return View(hospitales);
        }

        private IEnumerable<ConsultaARSHospital.Hospitales> ObtenerHospitalesDesdeLaBaseDeDatos()
        {
            return db.Hospitales.ToList();
        }

        // Otros métodos del controlador...

        public ActionResult Contact()
        {

            var doctores = db.Doctores.ToList();
            return View("Contact", doctores);
        }

        public ActionResult Mision()
        {
            var especialidades = db.Especialidades.ToList();
            return View("Mision", especialidades);
        }

        public ActionResult IndexDoctores(int idHospital)
        {
            var doctores = db.Doctores.Where(d => d.id_hospital == idHospital).ToList();
            return View("Contact", doctores);
        }

        public ActionResult DetallesHospitales(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Hospitales hospital = db.Hospitales.Find(id);
            if (hospital == null)
            {
                return HttpNotFound();
            }

            return View(hospital);
        }
        public ActionResult CrearHospitales()
        {
            return View("CrearHospitales");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearHospitales([Bind(Include = "id_hospital,nombre_hospital,direccion,telefono")] Hospitales hospitales)
        {
            if (ModelState.IsValid)
            {
                db.Hospitales.Add(hospitales);
                db.SaveChanges();
                return RedirectToAction("About");
            }

            return View("CrearHospitales", hospitales);
        }

        public ActionResult EditarDoctor(int? id)
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

        // POST: Seguros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarDoctor([Bind(Include = "id_doctor, nombre, apellido, email, telefono, id_hospital")] Doctores doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Contact");
            }
            return View(doctor);
        }

        public ActionResult EditarHospitales(int? id)
        {
            var hospitales = db.Hospitales.Find(id);
            if (hospitales == null)
            {
                return HttpNotFound();
            }
            return View(hospitales);
        }

        // POST: Seguros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarHospitales([Bind(Include = "id_hospital,nombre_hospital,direccion,telefono")] Hospitales hospitales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospitales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("About");
            }
            return View(hospitales);
        }

        public ActionResult EliminarHospitales(int? id)
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
            return View("EliminarHospitales", hospitales);
        }

        [HttpPost, ActionName("EliminarHospitales")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarHospitalesConfirmado(int id)
        {
            Hospitales hospitales = db.Hospitales.Find(id);
            db.Hospitales.Remove(hospitales);
            db.SaveChanges();
            return RedirectToAction("about");
        }



        public ActionResult DetallesDoctor(int? id)
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

        public ActionResult CrearDoctor()
        {
            return View("CrearDoctor");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearDoctor([Bind(Include = "id_doctor, nombre, apellido, email, telefono, id_hospital")] Doctores doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctores.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Contact");
            }

            return View("CrearDoctor", doctor);
        }


        // GET: Home/EliminarDoctor/5
        public ActionResult EliminarDoctor(int? id)
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

            return View("EliminarDoctor", doctor);
        }

        [HttpPost, ActionName("EliminarDoctor")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarEliminarDoctor(int id)
        {
            Doctores doctor = db.Doctores.Find(id);
            db.Doctores.Remove(doctor);
            db.SaveChanges();
            return RedirectToAction("Contact");
        }


        public ActionResult DetallesEspecialidades(int? id)
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


        public ActionResult CrearEspecialidades()
        {
            ViewBag.Doctores = new SelectList(db.Doctores, "id_doctor", "nombre");
            return View("CrearEspecialidades");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearEspecialidades([Bind(Include = "id_especialidad, nombre_especialidad, descripcion, id_doctor")] Especialidades especialidades)
        {
            if (ModelState.IsValid)
            {
                db.Especialidades.Add(especialidades);
                db.SaveChanges();
                return RedirectToAction("Mision");
            }

            return View("CrearEspecialidades", especialidades);
        }


        // GET: Home/EditarEspecialidad/5
        public ActionResult EditarEspecialidades(int id)
        {
            var especialidad = db.Especialidades.Find(id);
            if (especialidad == null)
            {
                return HttpNotFound();
            }
            return View(especialidad);
        }

        // POST: Home/EditarEspecialidad/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarEspecialidades(int id, Especialidades especialidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Mision");
            }
            return View(especialidad);
        }

        // GET: Home/EliminarEspecialidades/5
        public ActionResult EliminarEspecialidades(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Especialidades especialidad = db.Especialidades.Find(id);
            if (especialidad == null)
            {
                return HttpNotFound();
            }

            return View("EliminarEspecialidades", especialidad);
        }

        [HttpPost, ActionName("EliminarEspecialidades")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarEspecialidadesConfirmado(int id)
        {
            Especialidades especialidad = db.Especialidades.Find(id);
            db.Especialidades.Remove(especialidad);
            db.SaveChanges();
            return RedirectToAction("Mision");
        }


    }
}
