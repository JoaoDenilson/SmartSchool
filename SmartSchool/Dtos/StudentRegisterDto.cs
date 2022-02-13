using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Dtos
{
    /// <summary>
    /// Este é o DTO de Aluno para Registrar
    /// </summary>
    public class StudentRegisterDto
    {   
        /// <summary>
        /// Identificador e chave primária do banco
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Chave do Aluno, para outros negócios na Instituição.
        /// </summary>
        public int RegistrationId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime DateBirth { get; set; }
        public DateTime DateStart { get; set; } = DateTime.Now;
        public DateTime? DateEnd { get; set; } = null;
        public bool Active { get; set; } = true;
    }
}
