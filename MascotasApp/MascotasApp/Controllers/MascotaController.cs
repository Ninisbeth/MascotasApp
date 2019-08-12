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
                return View(listadoMascotas);
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
    }
}