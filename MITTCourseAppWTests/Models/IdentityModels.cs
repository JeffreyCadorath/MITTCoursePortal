using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MITTCourseAppWTests.Models
{
    
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Course> Courses { get; set; }
        public PersonType personType { get;set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public enum PersonType
    {
        Admin,
        Teacher,
        Student
    }

    public class ApplicationUserCourse
    {
        public ApplicationUserCourse(ApplicationUser applicationUser, Course course)
        {
            this.ApplicationUser = applicationUser;
            this.Course = course;
            this.ApplicationUserId = applicationUser.Id;
            this.CourseId = course.Id;
        }
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public DateTime dateJoined { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<ApplicationUserCourse> ApplicationUserCourses { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}