﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_VB2.Models
{
    public class OpslagViewModel
    {
        [Display(Name = "Van wedde:")]
        [Required(ErrorMessage = "Van wedde is een verplicht veld")]
        public decimal? VanWedde { get; set; }
        [Display(Name = "Tot wedde:")]
        [Required(ErrorMessage = "Tot wedde is een verplicht veld")]
        public decimal? TotWedde { get; set; }
        [Display(Name = "Percentage:")]
        [Required(ErrorMessage = "Percentage is een verplicht veld")]
        [Range(1, 100, ErrorMessage = "De minimum- en maximumwaarden voor percentage zijn : {1} en {2}")]
        public decimal Percentage { get; set; }
    }
}