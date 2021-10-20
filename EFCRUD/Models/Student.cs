using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCRUD.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required]
        [MaxLength(10)]
        public string MobileNo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [ForeignKey("City")]
        [Required]
        public int CityId { get; set; }
        [ForeignKey("State")]
        [Required]
        public int StateId { get; set; }
        [ForeignKey("Country")]
        [Required]
        public int CountryId { get; set; }
        [ForeignKey("Course")]
        [Required]
        public int CourseId { get; set; }
        [Required]
        public string Zipcode { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]
        public string PassedOut { get; set; }

        // navigation property

        public virtual City City { get; set; }
        public virtual State State { get; set; }
        public virtual Country Country { get; set; }
        public virtual Course Course { get; set; }

    }
}