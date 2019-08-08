using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MITTCourseAppWTests.Models
{
    public class Course
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public string Title { get; set; }
        public virtual ICollection<ApplicationUserCourse> CourseUsers { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Credits { get; set; }
    }
}