using MVC_VB2.Models;
using MVC_VB2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_VB2.Controllers
{
    public class BierController : Controller
    {

        private BierService bierService = new BierService();

        // GET: Bier
        public ActionResult Index()
        {
            return View(bierService.FindAll());
        }

        public ActionResult Verwijderen(int id)
        {
            var bieren = bierService.Read(id);
            return View(bieren);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var bier = bierService.Read(id);
            this.TempData["bier"] = bier;
            bierService.Delete(id);
            return RedirectToAction("Verwijderd");
        }

        public ActionResult Verwijderd()
        {
            var bier = (Bier)this.TempData["bier"];
            return View(bier);
        }

        [HttpGet]
        public ActionResult Toevoegen()
        {
            var bier = new Bier();
            return View(bier);
        }

        [HttpPost]
        public ActionResult Toevoegen(Bier b)
        {
            if (this.ModelState.IsValid)
            {
                bierService.Add(b);
                return RedirectToAction("Index");
            }
            else
            {
                return View(b);
            }
        }
    }
}