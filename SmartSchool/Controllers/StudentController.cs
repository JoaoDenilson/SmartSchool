using Microsoft.AspNetCore.Mvc;
using SmartSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public List<Student> Students = new List<Student>()
        {
            new Student(){
                Id = 1,
                Name = "Joao",
                Phone = "8899223344"
            },
            new Student(){
                Id = 2,
                Name = "Pedro",
                Phone = "8899223344"
            },
            new Student(){
                Id = 3,
                Name = "Maria",
                Phone = "8899223344"
            },
            new Student(){
                Id = 4,
                Name = "Lucas",
                Phone = "8899223344"
            },
        };
        // GET: api/<StudentController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Students);
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = Students.FirstOrDefault(a => a.Id == id);
            if (student == null)
            {
                return BadRequest();
            }
            return Ok(student);
        }

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post(Student student)
        {
            return Ok(student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            return Ok(student);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Student student)
        {
            return Ok(student);
        }
        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
