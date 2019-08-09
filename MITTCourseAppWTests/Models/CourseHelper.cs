using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MITTCourseAppWTests.Models
{
    public class CourseHelper
    {
        ApplicationDbContext db;
        UserManager<ApplicationUser> usersManager;
        public CourseHelper(ApplicationDbContext db)
        {
            this.db = db;
            usersManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }
        public ApplicationUser CheckUserId(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var user = db.Users.Find(userId);
                if (user != null)
                {
                    return user;
                }
            }
            return null;
        }
        public Course CheckCourseId(int courseId)
        {
            var course = db.Courses.Find(courseId);
            if (course == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                return course;
            }
        }
        public ICollection<Course> allCourses()
        {
            var allCourses = db.Courses.ToList();
            return allCourses;
        }
        public void AddStudentToCourse(string studentId, int courseId)
        {
            if(db.Users.Any(x => x.personType == PersonType.Student))
            {
                var student = CheckUserId(studentId);
                var course = CheckCourseId(courseId);
                var UserCourse = db.ApplicationUserCourses.FirstOrDefault(x => x.CourseId == course.Id && x.ApplicationUserId == studentId);
                if (!course.CourseUsers.Contains(UserCourse))
                {
                    if (course != null && student != null && UserCourse != null)
                    {
                        if (course.CourseUsers.Count > course.Capacity)
                        {
                            course.CourseUsers.Add(new ApplicationUserCourse(student, course));
                            db.SaveChanges();
                        }
                        else
                        {
                            return;
                        }
                    }

                }
            }
        }
        public void AddInsturctorToCourse(string instructorId, int courseId)
        {
            var instructor = db.Users.Find(instructorId);
            var course = CheckCourseId(courseId);
            var UserCourse = db.ApplicationUserCourses.FirstOrDefault(x => x.CourseId == course.Id && x.ApplicationUserId == instructorId);
            if (db.Users.Any(x => x.personType == PersonType.Teacher))
            {
                if (course != null && instructor != null && UserCourse != null)
                {
                    course.CourseUsers.Add(new ApplicationUserCourse(instructor, course));
                    db.SaveChanges();
                }
            }
        }
        public ICollection<ApplicationUser> GetAllStudents()
        {
            var students = db.Users.Where(x => x.personType == PersonType.Student).ToList();
            return students;
        }

    }
}