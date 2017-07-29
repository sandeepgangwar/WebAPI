using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TrainingCompany.Controllers
{
    public class Course
    {
        public int id;
        public string title;
    }

    public class CoursesController : ApiController
    {
        private static List<Course> courses = InitCourses();

        private static List<Course> InitCourses()
        {
            return new List<Course>
            {
                new Course { id=0, title="Web Api" },
                new Course { id=1, title="MVC" },
                new Course { id=2, title="Javascript" }

            };
        }

        public IEnumerable<Course> Get()
        {
            return courses;
        }

        public void Post([FromBody] Course course)
        {
            courses.Add(course);
        }

        public void Put(int id ,[FromBody] Course course)
        {
            var c = courses.FirstOrDefault(cr => cr.id == id);
            c.title = course.title;
        }

        public void Delete(int id)
        {
            courses.RemoveAt(id);
        }
        

        public HttpResponseMessage Get(int id)
        {
            var course = courses.FirstOrDefault(c => c.id == id);
            if(courses != null)
            {
                return Request.CreateResponse(HttpStatusCode.Found, course);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}
