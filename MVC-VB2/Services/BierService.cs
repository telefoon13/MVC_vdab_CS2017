using MVC_VB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_VB2.Services
{
    public class BierService
    {
        private static Dictionary<int, Bier> bieren = new Dictionary<int, Bier>();

        static BierService()
        {
            bieren[1] = new Bier { ID = 1, Naam = "Jupiler", Alcohol = 1.2f };
            bieren[2] = new Bier { ID = 2, Naam = "Maes", Alcohol = 2.1f };
            bieren[3] = new Bier { ID = 3, Naam = "Duvel", Alcohol = 5.1f };
            bieren[4] = new Bier { ID = 4, Naam = "West Malle", Alcohol = 8.1f };
            bieren[5] = new Bier { ID = 5, Naam = "Cara pils", Alcohol = 2f };
            bieren[6] = new Bier { ID = 6, Naam = "Bokkereyder", Alcohol = 4.6f };
            bieren[7] = new Bier { ID = 7, Naam = "Lambik", Alcohol = 9.3f };
            bieren[8] = new Bier { ID = 8, Naam = "Kriek", Alcohol = 4.8f };
            bieren[9] = new Bier { ID = 9, Naam = "Westvleteren", Alcohol = 12f };
            bieren[10] = new Bier { ID = 10, Naam = "Rochefort", Alcohol = 10f };
        }

        public List<Bier> FindAll()
        {
            return bieren.Values.ToList();
        }

        public Bier Read(int id)
        {
            return bieren[id];
        }

        public void Delete(int id)
        {
            bieren.Remove(id);
        }

        public void Add(Bier b)
        {
            b.ID = bieren.Keys.Max() + 1;
            bieren.Add(b.ID, b);
        }
    }
}