using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EFCRUD.Models;

namespace EFCRUD.Controllers
{
    public class LoginController : Controller
    {
        CourseDbContext db = new CourseDbContext();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Userdata = db.Users.Single(u => u.username == user.username && u.password == user.password);
            if (Userdata != null)
            {
                FormsAuthentication.SetAuthCookie(Userdata.Id.ToString() + "|" + Userdata.username, true);
                Session["id"] = Userdata.Id;
                Session["firstname"] = Userdata.firstname;
                Session["lastname"] = Userdata.lastname;
                Session["username"] = Userdata.username;
                Session["phoneno"] = Userdata.phoneno;
                Session["email"] = Userdata.email;
                Session["image"] = Userdata.image;
                Session["role"] = Userdata.Role.RoleName;

                if (Userdata.Role.RoleName == "Student")
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (Userdata.Role.RoleName == "Admin" || Userdata.Role.RoleName == "Teacher")
                {
                    return RedirectToAction("Index", "Profile");
                }
            }
            else
            {
                ViewBag.message = "Invalide Username or Password";
            }
            return View();
        }
    }
}