using StudentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_BusinessLayer
{
    public interface IStudentBusinessAccess
    {
        IEnumerable<Student> DisplayStudent();
        void DeleteStudent(int id);
        void EditStudent(Student student);
        void AddStudent(Student student);
        Student GetById(int id);
    }
}
