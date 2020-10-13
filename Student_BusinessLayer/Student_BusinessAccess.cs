using Student_DataAccessLayer;
using StudentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_BusinessLayer
{
    public class Student_BusinessAccess : IStudentBusinessAccess
    {
        private readonly IStudentDataAccess studentDataAccess;
        public Student_BusinessAccess()
        { 
            this.studentDataAccess = new Student_DataAccess();
        }

        public IEnumerable<Student> DisplayStudent()
        {
            return studentDataAccess.DisplayStudent();
        }
        public void DeleteStudent(int id)
        {
            studentDataAccess.DeleteStudent(id);
        }

        public void EditStudent(Student student)
        {
            studentDataAccess.EditStudent(student);
        }

        public void AddStudent(Student student)
        {
            studentDataAccess.PostStudent(student);
        }

        public Student GetById(int id)
        {
            return studentDataAccess.GetById(id);
        }
    }
}
