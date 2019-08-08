namespace MITTCourseAppWTests.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MITTCourseAppWTests.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MITTCourseAppWTests.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (!context.Roles.Any(x => x.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                manager.Create(new IdentityRole("Admin"));
                manager.Create(new IdentityRole("Teacher"));
                manager.Create(new IdentityRole("Student"));
            }


            context.Courses.AddOrUpdate(new Models.Course { Title = "MAth foR ThE IlliTerate", Capacity = 12, Credits = 3, EndDate = DateTime.Now, StartDate = DateTime.Now });
            context.Courses.AddOrUpdate(new Models.Course { Title = "English For People Who Can't Speak Good", Capacity = 2, Credits = 6, EndDate = DateTime.Now, StartDate = DateTime.Now });

            context.Users.AddOrUpdate(new Models.ApplicationUser { Email = "student@email.com", PasswordHash = "1234-Jeff", UserName = "Tommy", personType = Models.PersonType.Student });
            context.Users.AddOrUpdate(new Models.ApplicationUser { Email = "teacher@email.com", PasswordHash = "1234-Jeff", UserName = "Ted", personType = Models.PersonType.Teacher });
            context.Users.AddOrUpdate(new Models.ApplicationUser { Email = "admin@email.com", PasswordHash = "1234-Jeff", UserName = "Frank", personType = Models.PersonType.Admin });

        }
    }
}
