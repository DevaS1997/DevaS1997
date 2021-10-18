using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFCRUD.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public float Fees { get; set; }
        public string image { get; set; }

        //navigation property

        public virtual ICollection<Student> Students { get; set; }
    }
}