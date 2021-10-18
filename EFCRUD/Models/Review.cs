using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFCRUD.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Reviews { get; set; }
        [Required]
        public int Rating { get; set; }
        [ForeignKey("Blog")]
        public int BlogId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public DateTime Date { get; set; }

        //navigation property
        public virtual User User { get; set; }
        public virtual Blog Blog { get; set; }
    }
}