using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_VB2.Models
{
    public class Wernemer
    {
        public String naam { get; set; }
        public decimal Wedde { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime InDienst { get; set; }
    }
}