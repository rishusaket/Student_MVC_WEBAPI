using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEntities
{
    public enum GenderTypes
    {
        Male,
        Female
    }
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="This is a Required Field")]
        [StringLength(10, ErrorMessage ="Name should be 10 characters")]
        public string name { get; set; }
        [Required(ErrorMessage = "This is a Required Field")]
        public string gender { get; set; }
        [Required(ErrorMessage="This is a Required Field")]
        public string location { get; set; }
    }
}
