using MVC_VB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_VB2.Controllers
{
    // Uitschakelen van Sessions in een volledige controller --> beter performantie
    //[SessionState(SessionStateBehavior.Disabled)]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            String resultaat = "Welkom dit is je eerste bezoek.";
            if (Request.Cookies != null)
            {
                if (Request.Cookies["lastVisit"] != null)
                {
                    resultaat = "Welkom terug. Jouw laatste bezoek was op " + Request.Cookies["lastVisit"]["tijdstip"] + ". Jouw voorkeurtaal is " + Request.Cookies["lastVisit"]["taal"] + ".";
                }

                String laatsteBezoek = DateTime.Now.ToString();
                var userCookie = new HttpCookie("lastVisit");
                userCookie["tijdstip"] = laatsteBezoek;
                userCookie["taal"] = Request.UserLanguages[0];
                userCookie.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(userCookie);
            }
            ViewBag.Tijdstip = resultaat;

            //Session bezoeken optellen
            this.Session["aantalBezoeken"] = (int)this.Session["aantalBezoeken"] + 1;

            // Application state variable
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["aantalBezoeken"] = (int)System.Web.HttpContext.Current.Application["aantalBezoeken"] + 1;
            System.Web.HttpContext.Current.Application.UnLock();

            return View();
        }

        public ActionResult Wissen()
        { //zijn er cookies?
            if (Request.Cookies != null)
            {
                //is er een cookies met de naam "lastvisit"?
                if (Request.Cookies["lastVisit"] != null)
                {
                    Request.Cookies["lastVisit"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(Request.Cookies["lastVisit"]);
                }
            }
            return View();
        }

        public ActionResult WissenSession()
        {
            // Controle dient niet meer te gebeuren aangezien session word gemaakt in Global.asax
            // if (this.Session["aantalBezoeken"] != null)
            // {
                this.Session["aantalBezoeken"] = null;
                // Om alle sessies te wissen 
                // Session.Clear();
                // Foreach over alles sessies
                // foreach (object sessionVariabele in Session) { ... };
            //}
            return View();
        }

        public ActionResult WissenApplication()
        {
            //reset applicationvariabele
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["aantalBezoeken"] = 0;
            System.Web.HttpContext.Current.Application.UnLock();

            return View();
        }
        
            public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Palindroom(string woord)
        {
            char[] omgekeerd = woord.ToCharArray();
            Array.Reverse(omgekeerd);
            string achterstevoren = new string(omgekeerd);

            if (woord == achterstevoren)
                ViewBag.palindroom = true;
            else
                ViewBag.palindroom = false;

            ViewBag.ingetiktwoord = woord;
            return View();
        }

        public PartialViewResult GetTime()
        {
            return PartialView(DateTime.Now);
        }
    }
}