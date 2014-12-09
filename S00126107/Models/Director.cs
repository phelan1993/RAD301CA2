using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S00126107.Models
{
    public class Director : Person
    {
        [Key]
        public int DirectorId { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        // TODO: Possibly add director specific content at later date
    }
}