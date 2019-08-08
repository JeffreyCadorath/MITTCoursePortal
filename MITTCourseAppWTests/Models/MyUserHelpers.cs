using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MITTCourseAppWTests.Models
{
    public class MyUserHelpers
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ICollection<ApplicationUser> Teachers()
        {
            var allTeachers = db.Users.Where(x => x.personType == PersonType.Teacher).ToList();
            return allTeachers;
        }

        public ICollection<ApplicationUser> Students()
        {
            var allStudents = db.Users.Where(x => x.personType == PersonType.Student).ToList();
            return allStudents;
        }
        public ICollection<ApplicationUser> Admins()
        {
            var allAdmins = db.Users.Where(x => x.personType == PersonType.Admin).ToList();
            return allAdmins;
        }

    }
}