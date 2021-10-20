using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;
using System.Net;
using System.Web.Mvc;
using EFCRUD.Models;
namespace EFCRUD.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            CourseDbContext db = new CourseDbContext();
            var user_id = Convert.ToInt32(@Session["id"]);
            //viewmodel views = new viewmodel();
            //IEnumerable<Student> student = db.Students.Include(u => u.Id == user_id).ToList();
            IEnumerable<User> user = db.Users.Where(u => u.Id == user_id).ToList();
            //views.user = user.ToList();
            //views.student = student.ToList();
            return View(user);
        }
    }

}