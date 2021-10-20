using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFCRUD.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string autonumber { get; set; }
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


        // navigation property
        public virtual City City { get; set; }
        public virtual State State { get; set; }
        public virtual Country Country { get; set; }
    }
}