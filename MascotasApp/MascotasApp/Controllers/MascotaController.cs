using MascotasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MascotasApp.Controllers
{
    public class MascotaController : Controller
    {
        const string nombreSesion = "ListadoMascota";
        public ActionResult Index()
        {
            if (Session[nombreSesion] == null)
            {
                var listadoMascotas = ObtenerMascotas();
                Session[nombreSesion] = listadoMascotas;
                return View(listadoMascotas);
            }
            else
            {
                var listadoMascotas = (List<Mascota>)Session[nombreSesion];
                return View(listadoMascotas.OrderBy(x=> x.Id).ToList());
            }
        }

        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(Mascota mascota)
        {
            var listadoMascotas = (List<Mascota>)Session[nombreSesion];
            listadoMascotas.Add(mascota);
            Session[nombreSesion] = listadoMascotas;
            return RedirectToAction("Index");
        }
        private List<Mascota> ObtenerMascotas()
        {
            var Listado = new List<Mascota>();
            Listado.Add(new Mascota { Id = 1, Edad = 2, Nombre = "Trusty", NombreDueno = "Nini", Raza = "Perro" });
            Listado.Add(new Mascota { Id = 2, Edad = 8, Nombre = "Tonti", NombreDueno = "victor", Raza = "Gato" });
            Listado.Add(new Mascota { Id = 3, Edad = 1, Nombre = "Paco", NombreDueno = "Maria", Raza = "Loro" });

            return Listado;
        }

        public ActionResult Actualizar(int id)
        {
            var listadoMascotas = (List<Mascota>)Session[nombreSesion];
            var mascota = listadoMascotas.FirstOrDefault(x => x.Id == id);
            return View(mascota);
        }

        [HttpPost]
        public ActionResult Actualizar(Mascota mascota)
        {
            var listadoMascotas = (List<Mascota>)Session[nombreSesion];
            var mascotaActualizar = listadoMascotas.FirstOrDefault(x => x.Id == mascota.Id);
            listadoMascotas.Remove(mascotaActualizar);
            listadoMascotas.Add(mascota);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            var listadoMascotas = (List<Mascota>)Session[nombreSesion];
            var mascotaActualizar = listadoMascotas.FirstOrDefault(x => x.Id == id);
            listadoMascotas.Remove(mascotaActualizar);
            return RedirectToAction("Index");
        }
    }
}