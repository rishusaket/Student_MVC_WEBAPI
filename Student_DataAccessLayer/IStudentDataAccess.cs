using StudentEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_DataAccessLayer
{
    public interface IStudentDataAccess
    {
        IEnumerable<Student> DisplayStudent();
        void DeleteStudent(int id);
        void PostStudent(Student student);
        void EditStudent(Student student);
        Student GetById(int id);
    }
}
