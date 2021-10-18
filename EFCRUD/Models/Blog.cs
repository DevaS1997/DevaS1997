using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Web.Mvc;

namespace EFCRUD.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        [AllowHtml]
        public string Description { get; set; }
        public string image { get; set; }
        public DateTime? CreateOn { get; set; }
        public DateTime? UpadateOn { get; set; }
        public string createdby { get; set; }
        public string updatedby { get; set; }
        public int? rating { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [ForeignKey("BlogCategory")]
        public int BlogCategoryId { get; set; }
        //[ForeignKey("User")]
        //[DefaultValue("1")]
        //public int UsersId { get; set; }
        //navigation property
        public virtual BlogCategory BlogCategory { get; set; }
        //public virtual User User { get; set; }

    }
}