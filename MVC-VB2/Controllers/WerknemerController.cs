using MVC_VB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_VB2.Controllers
{
    public class WerknemerController : Controller
    {
        // GET: Werknemer
        public ActionResult Index()
        {
            return View();
        }

        [NonAction]
        public void GeenAction()
        {
            //geen actie via request
        }

        [ActionName("Lijst")]
        public ActionResult AlleWerknemers()
        {
            var werknemers = new List<Wernemer>();
            werknemers.Add(new Wernemer { naam = "Mike", Wedde = 3500m, InDienst = DateTime.Today.AddYears(-1) });
            werknemers.Add(new Wernemer { naam = "Jan", Wedde = 2500m, InDienst = DateTime.Today.AddYears(-2) });
            werknemers.Add(new Wernemer { naam = "Tom", Wedde = 3000m, InDienst = DateTime.Today.AddYears(-1).AddDays(-5) });
            werknemers.Add(new Wernemer { naam = "Jess", Wedde = 500m, InDienst = DateTime.Today.AddYears(-1).AddMonths(2) });
            werknemers.Add(new Wernemer { naam = "Mama", Wedde = 5000m, InDienst = DateTime.Today.AddYears(-3) });

            return View("AlleWerknemers",werknemers);
        }
    }
}