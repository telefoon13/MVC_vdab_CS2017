using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_VB2.Models
{
    public class Bier
    {
        [DisplayFormat(DataFormatString = "{0:000}")]
        public int ID { get; set; }

        [StringLength(20, ErrorMessage = "Max. {1} tekens voor {0}")]
        public String Naam { get; set; }

        [UIHint("kleurAlcohol")]
        [Range(0,15, ErrorMessage = "Min. {1} en max {2}")]
        public float Alcohol { get; set; }
    }
}