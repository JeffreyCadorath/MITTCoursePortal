using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MITTCourseAppWTests.Models;

namespace MITTCourseAppWTests.Tests
{
    [TestClass]
    public class CourseUnitTests
    {
        string userIdTest = "4f573747-ebc4-41c0-a98c-ba339408ed9e";
        int courseTestId = 3;
        [TestMethod]
        public void GetAllCourses()
        {
            CourseHelper ch = new CourseHelper(new ApplicationDbContext());
            var courses = ch.allCourses();
            Assert.IsNotNull(courses);
        }
        public void AddStudentToTest()
        {

        }
    }
}
