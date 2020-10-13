using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student_MVC.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string name { get; set; }
        
        public string gender { get; set; }
       
        public string location { get; set; }
    }
}