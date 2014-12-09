using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S00126107.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string Title { get; set; }
        // nav properties
        public virtual List<Movie> Movie { get; set; }
    }
}