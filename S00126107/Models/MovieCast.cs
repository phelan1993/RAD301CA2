using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace S00126107.Models
{
    public class MovieCast
    {
        [Key, Column(Order = 0)] // composite key 1
        public int MovieId { get; set; }
        [Key, Column(Order = 1)] // composite key 2
        public int ActorId { get; set; }
        public string ScreenName { get; set; }
        // nav properties
        public virtual Movie Movie { get; set; }
        public virtual Actor Actor { get; set; }
    }
}