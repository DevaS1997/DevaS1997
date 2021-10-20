using EFCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Security;
using System.Net;
using System.Web.Routing;

namespace EFCRUD.Controllers
{
    public class HomeController : Controller
    {
        private CourseDbContext db = new CourseDbContext();
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.City).Include(s => s.Country).Include(s => s.Course).Include(s => s.State);
            var blog = db.Blogs.Include(b => b.BlogCategory);
            blog = blog.OrderByDescending(x => x.CreateOn).Take(3);
            viewmodel view = new viewmodel();
            //foreach (var i in blog)
            //{
            //    view.user = db.Users.Where(u => u.Id == Convert.ToInt32(i.updatedby)).ToList();
            //}
            view.blog = blog.ToList();
            view.blogcategory = db.BlogCategories.ToList();
            //view.review = reviews;
            return View(view);
        }

        public ActionResult Blog()
        {
            var students = db.Students.Include(s => s.City).Include(s => s.Country).Include(s => s.Course).Include(s => s.State);
            var blog = db.Blogs.Include(b => b.BlogCategory);
            viewmodel view = new viewmodel();
            view.blog = blog.ToList();
            view.blogcategory = db.BlogCategories.ToList();
            return View(view);
        }

        public ActionResult DriverDetail(int? id)
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult BlogDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var blog = db.Blogs.Where(x => x.Id == id).ToList();
            var rating = db.Reviews.Include(u => u.User).Where(r => r.BlogId == id).ToList();
            viewmodel view = new viewmodel();
            view.blog = blog;
            view.blogcategory = db.BlogCategories.ToList();
            view.review = rating;
            if (blog == null)
            {
                return HttpNotFound();
            }

            return View(view);
        }

        public ActionResult Review(Review review)
        {

            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                //var routeValues = new RouteValueDictionary() {
                //    { "id", review.BlogId},
                //    {"success","kSuccess"}
                //};
                //(from a in db.Reviews where a.ReviewsRestaurantID.Equals(id) select a.ReviewsRating).Average();
                var avg = Convert.ToInt32((from a in db.Reviews where a.BlogId.Equals(review.BlogId) select a.Rating).Average());
                var blog = db.Blogs.Find(review.BlogId);
                blog.rating = avg;
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                TempData["success"] = "Thank You For Rating and Review";
                return RedirectToAction("BlogDetail", "Home", new { id = review.BlogId });
            }
            return RedirectToAction("BlogDetail", "Home", new { id = review.BlogId });
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public RedirectToRouteResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login", "login");
        }
    }

    public class viewmodel
    {
        public List<Blog> blog = new List<Blog>();
        public List<BlogCategory> blogcategory = new List<BlogCategory>();
        public List<User> user = new List<User>();
        public List<Student> student = new List<Student>();
        public List<Review> review = new List<Review>();
    }

}