using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S00126107.Models
{
    public enum Language { English, Irish, French, German, Spanish }

    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        public string Title { get; set; }
        [Display(Name = "Release Date"),
        DataType(DataType.Date), DisplayFormat(
        DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ReleaseDate { get; set; }
        public int Rating { get; set; }
        public Certificate Certificate { get; set; }
        [Display(Name = "Running Time")]
        public int Runtime { get; set; }
        public Language Language { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        // nav properties
        public virtual Genre Genre { get; set; }
        public virtual Director Director { get; set; }
        public virtual ICollection<MovieCast> Cast { get; set; }

        public virtual ICollection<Actor> Actors
        {
            get { return (Cast == null) ? null : Cast.Select(c => c.Actor).ToList(); }
        }
    }
}