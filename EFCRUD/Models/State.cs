using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFCRUD.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string StateName { get; set; }


        // navigation property
        public virtual ICollection<City> Cities { get; set; }
    }
}