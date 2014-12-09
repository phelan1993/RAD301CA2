using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S00126107.Models
{
    public class Actor : Person
    {
        [Key]
        public int ActorId { get; set; }
        // TODO: Possibly add actor specific content at later date
        public virtual ICollection<MovieCast> MovieCasts { get; set; }
        public virtual ICollection<Movie> Movies
        {
            get { return (MovieCasts == null) ? null : MovieCasts.Select(mc => mc.Movie).ToList(); }
        } 
    }
}