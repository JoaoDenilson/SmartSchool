using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public int RegistrationId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public DateTime DateStart { get; set; }
        public bool Active { get; set; } = true;
    }
}
