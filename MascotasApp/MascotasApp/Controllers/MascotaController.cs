using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MascotasApp.Controllers
{
    public class MascotaController : Controller
    {
        // GET: Mascota
        public ActionResult Index()
        {
            return View();
        }
    }
}