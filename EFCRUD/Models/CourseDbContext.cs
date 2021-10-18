using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
//using Microsoft.AspNet.Identity;

namespace EFCRUD.Models
{
    class CourseDbContext : DbContext
    {
        public CourseDbContext() : base("CourseDb")
        { }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<BlogCategory> BlogCategories { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        public override int SaveChanges()
        {
            foreach (var entity in this.ChangeTracker.Entries().Where(e => e.Entity is Blog && e.State == EntityState.Added))
            {
                entity.Property("CreateOn").CurrentValue = DateTime.Now;
                entity.Property("createdby").CurrentValue = HttpContext.Current.User.Identity.Name.Split('|')[1];
                entity.Property("UpadateOn").CurrentValue = DateTime.Now;
                entity.Property("updatedby").CurrentValue = HttpContext.Current.User.Identity.Name.Split('|')[1];
            }
            foreach (var entity in this.ChangeTracker.Entries().Where(e => e.Entity is Blog && e.State == EntityState.Modified))
            {
                entity.Property("CreateOn").IsModified = false;
                entity.Property("createdby").IsModified = false;
                entity.Property("UpadateOn").CurrentValue = DateTime.Now;
                entity.Property("updatedby").CurrentValue = HttpContext.Current.User.Identity.Name.Split('|')[1];
            }
            return base.SaveChanges();
        }
    }
}