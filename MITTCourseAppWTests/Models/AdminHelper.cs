using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MITTCourseAppWTests.Models
{
    public class AdminHelper
    {
        ApplicationDbContext db;
        UserManager<ApplicationUser> usersManager;
        RoleManager<IdentityRole> rolesManager;
        public AdminHelper(ApplicationDbContext db)
        {
            this.db = db;
            usersManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            rolesManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
        }
        public void AddRole(string roleName)
        {
            rolesManager.Create(new IdentityRole(roleName));
        }
        public void AddToRole(string userId, string roleName)
        {
            if (!usersManager.IsInRole(userId, roleName))
            {
                if(db.Users.Any(x => x.personType == PersonType.Admin))
                {
                    usersManager.AddToRole(userId, roleName);
                    db.SaveChanges();
                }
            }
        }

        public void RemoveFromRole(string userId, string roleName)
        {
            if(usersManager.IsInRole(userId, roleName))
            {
                usersManager.RemoveFromRole(userId, roleName);
                db.SaveChanges();
            }
        }

        public void RemoveCourse(string userId, string roleName, Course course)
        {
            if(usersManager.IsInRole(userId, "Admin"))
            {
                db.Courses.Remove(course);
                db.SaveChanges();
            }
        }
    }
}