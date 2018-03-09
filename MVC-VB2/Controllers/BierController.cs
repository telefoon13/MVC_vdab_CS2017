using MVC_VB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_VB2.Controllers
{
    public class BierController : Controller
    {
        // GET: Bier
        public ActionResult Index()
        {
            var bieren = new List<Bier>();
            bieren.Add(new Bier { ID = 1, Naam = "Jupiler", Alcohol = 3.5f });
            bieren.Add(new Bier { ID = 2, Naam = "Maes", Alcohol = 3.1f });
            bieren.Add(new Bier { ID = 3, Naam = "Duvel", Alcohol = 7.3f });
            bieren.Add(new Bier { ID = 4, Naam = "West Malle", Alcohol = 4.5f });
            bieren.Add(new Bier { ID = 5, Naam = "Cara pils", Alcohol = 1.5f });
            return View(bieren);
        }
    }
}