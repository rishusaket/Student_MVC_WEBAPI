using StudentEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_DataAccessLayer
{
    public class Student_DataAccess : IStudentDataAccess
    {
        private readonly SqlConnection connection;
        public Student_DataAccess()
        {
            ConnectionString connectionStringClassObject = new ConnectionString();
            this.connection = new SqlConnection(connectionStringClassObject.connectionString);
        }

        public IEnumerable<Student> DisplayStudent()
        {
            using(connection)
            {
                List<Student> students = new List<Student>();
                SqlCommand command = new SqlCommand("ViewStudent", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);

                foreach(DataRow row in dataTable.Rows)
                {
                    students.Add(new Student()
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        name = Convert.ToString(row["name"]),
                        gender = Convert.ToString(row["gender"]),
                        location = Convert.ToString(row["location"])
                    });

                }
                return students;
            }
        }
        public void PostStudent(Student student)
        {
            using (connection)
            {
                SqlCommand command = new SqlCommand("AddStudent", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", student.name);
                command.Parameters.AddWithValue("@gender", student.gender);
                command.Parameters.AddWithValue("@location", student.location);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void EditStudent(Student student)
        {
            using (connection)
            {
                SqlCommand command = new SqlCommand("EditStudent", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", student.Id);
                command.Parameters.AddWithValue("@name", student.name);
                command.Parameters.AddWithValue("@gender", student.gender);
                command.Parameters.AddWithValue("@location", student.location);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(int id)
        {
            using (connection)
            {
                SqlCommand command = new SqlCommand("DeleteStudent", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Student GetById(int id)
        {
            using (connection)
            {
                List<Student> students = DisplayStudent().ToList();
                Student student = students.FirstOrDefault(x => x.Id == id);
                //var commandText = "SELECT * from Student where Id = @id";
                //SqlCommand command = new SqlCommand(commandText,connection);
                //command.CommandType = CommandType.Text;
                //command.Parameters.AddWithValue("@id", id);
                //connection.Open();
                //Student student = (Student)command.ExecuteScalar();
                return student;
            }
        }
    }
}
