using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S00126107.Models
{
    public enum Certificate
    {
        [Display(Name = "G")]
        G,
        [Display(Name = "PG")]
        Pg,
        [Display(Name = "12A")]
        TwelveA,
        [Display(Name = "15A")]
        FifteenA,
        [Display(Name = "16A")]
        Sixteen,
        [Display(Name = "18")]
        Eighteen
    }
}