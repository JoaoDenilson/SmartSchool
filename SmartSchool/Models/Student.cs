using SmartSchool.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Models
{
    public class Student
    {
        public Student() { }
        public Student(int id, 
                       int registrationId,
                       string name, 
                       string lastName, 
                       string phone, 
                       DateTime dateBirth)
        {
            this.Id = id;
            this.Name = name;
            this.RegistrationId = registrationId;
            this.LastName = lastName;
            this.Phone = phone;
            this.DateBirth = dateBirth;
        }
        public int Id { get; set; }
        public int RegistrationId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime DateBirth { get; set; }
        public DateTime DateStart { get; set; } = DateTime.Now;
        public DateTime? DateEnd { get; set; } = null;
        public bool Active { get; set; } = true;
        public IEnumerable<StudentDiscipline> StudentsDiscipline { get; set; }
    }
}
