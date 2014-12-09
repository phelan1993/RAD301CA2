using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S00126107.Models
{
    public enum Gender { Male, Female }

    public class Person
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        [Display(Name = "Date of Birth"),
        DataType(DataType.Date), DisplayFormat(
        DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Country")]
        public string BirthPlace { get; set; }
        [Display(Name = "Profile Picture")]
        public string ImageUrl { get; set; }
        public string Bio { get; set; }
        [Display(Name = "Name")]
        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - DateOfBirth.Year;
                if (DateOfBirth > today.AddYears(-age)) age--;
                return age;
            }
        }
    }
}