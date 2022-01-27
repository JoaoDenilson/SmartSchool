using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Models
{
    public class Teacher
    {
        public Teacher() { }
        public Teacher(int id,
                       int registrationId,
                       string name,
                       string lastName
            )
        {
            this.Id = id;
            this.RegistrationId = registrationId;
            this.Name = name;
            this.LastName = lastName;
        }
        public int Id { get; set; }
        public int RegistrationId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime DateStart { get; set; } = DateTime.Now;
        public DateTime? DateEnd { get; set; } = null;
        public bool Active { get; set; } = true;
        public IEnumerable<Discipline> Disciplines { get; set; }
    }
}
