using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFCRUD.Models
{
    public class BlogCategory
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }
    }
}