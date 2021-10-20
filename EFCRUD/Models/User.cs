using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EFCRUD.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Invalid First Name")]
        [Display(Name = "First Name")]
        public string firstname { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string lastname { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required]
        [RegularExpression(@"^\d{10}$")]
        [Display(Name = "Mobile Number")]
        public string phoneno { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string username { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        // [FileExtensions]
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public string image { get; set; }
        [Required]
        public int RoleId { get; set; }

        // navigation property
        public virtual Role Role { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}