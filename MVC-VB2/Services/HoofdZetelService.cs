using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_VB2.Models;

namespace MVC_VB2.Services
{
    public class HoofdZetelService
    {
        public Hoofdzetel Read()
        {
            return new Hoofdzetel
            {
                Straat = "Keizerslaan",
                HuisNr = "11",
                PostCode = "1000",
                Gemeente = "Brussel"
            };
        }
    }
}