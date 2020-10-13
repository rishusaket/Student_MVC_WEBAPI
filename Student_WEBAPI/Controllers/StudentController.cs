using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Student_BusinessLayer;
using StudentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace Student_WEBAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StudentController : ApiController
    {
        // GET: api/Student
        private readonly Student_BusinessAccess emp =  new Student_BusinessAccess();
        public JsonResult<IEnumerable<Student>> Get()
        {
            return Json(emp.DisplayStudent());
        }
        public JsonResult<Student> Get(int id)
        {
            return Json(emp.GetById(id));
        }

        // POST: api/Student
        public JsonResult<HttpStatusCode> Post(Student student)
        {
            emp.AddStudent(student);
            return Json(HttpStatusCode.OK);

        }

        // PUT: api/Student/5
        public HttpResponseMessage Put(Student value)
        {
            emp.EditStudent(value);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE: api/Student/5
        public JsonResult<HttpStatusCode> Student(int id)
        {
            emp.DeleteStudent(id);
            
            return Json(HttpStatusCode.OK);
        }
    }
}
