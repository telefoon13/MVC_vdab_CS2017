﻿using MVC_VB2.Models;
using MVC_VB2.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_VB2.Controllers
{
    public class PersoonController : Controller
    {
        private PersoonService persoonService = new PersoonService();

        // GET: Persoon
        public ActionResult Index()
        {
            return View(persoonService.FindAll());
        }

        [HttpGet]
        public ActionResult VerwijderForm(int id)
        {
            return View(persoonService.FindByID(id));
        }

        [HttpPost]
        public ActionResult Verwijderen(int id)
        {
            persoonService.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Opslag()
        {
            OpslagViewModel opslagViewModel = new OpslagViewModel();
            opslagViewModel.Percentage = 10;
            return View(opslagViewModel);
        }

        [HttpPost]
        public ActionResult Opslag(OpslagViewModel opslagViewModel)
        {
            //Als er geen validatie fouten zijn
            if (this.ModelState.IsValid)
            {
                persoonService.Opslag(
                    opslagViewModel.VanWedde.Value,
                    opslagViewModel.TotWedde.Value,
                    opslagViewModel.Percentage);
                return RedirectToAction("Index");
            }
            else
            {
                return View(opslagViewModel);
            }
        }

        [HttpGet]
        public ActionResult VanTotWedde()
        {
            var form = new VanTotWeddeViewModel();
            return View(form);
        }

        [HttpGet]
        public ActionResult VanTotWeddeResultaat(VanTotWeddeViewModel form)
        {
            if (this.ModelState.IsValid)
            {
                form.Personen = persoonService.VanTotWedde(form.VanWedde.Value, form.TotWedde.Value);
            }

            return View("VanTotWedde", form);

        }

        [HttpGet]
        public ActionResult Toevoegen()
        {
            var persoon = new Persoon();
            persoon.Geslacht = Geslacht.Vrouw;
            return View(persoon);
        }

        [HttpPost]
        public ActionResult Toevoegen(Persoon p)
        {
            if (this.ModelState.IsValid)
            {
                persoonService.Add(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View(p);
            }
        }

        [HttpGet]
        public ActionResult EditForm(int id)
        {
            return View(persoonService.FindByID(id));
        }

        [HttpPost]
        public ActionResult Edit(Persoon p)
        {
            if (this.ModelState.IsValid)
            {
                persoonService.Update(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View("EditForm", p);
            }

        }

        public JsonResult ValidateDOB(string Geboren)
        {
            DateTime parsedDOB;
            if (!DateTime.TryParseExact(Geboren, "yyyy-mm-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDOB))
            {
                return Json("Gelieve een geldige datum in te voeren (dd/mm/jjjj) !", JsonRequestBehavior.AllowGet);
            }
            else if (DateTime.Now < parsedDOB)
            {
                return Json("Voer een datum uit het verleden in !", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult FilterPersonen(string gekozenGelacht = "Allebei")
        {
            return View((object)gekozenGelacht);
        }

        public PartialViewResult GetGefilterdePersonen(string gekozenGeslacht = "Allebei")
        {
            IEnumerable<Persoon> personen = persoonService.FindAll();
            if (gekozenGeslacht != "Allebei")
            {
                Geslacht gekozen = (Geslacht)Enum.Parse(typeof(Geslacht), gekozenGeslacht);
                personen = personen.Where(p => p.Geslacht == gekozen);
            }
            return PartialView(personen);
        }

    }
}