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
    public class TeacherController : ControllerBase
    {
        public List<Teacher> Teachers = new List<Teacher>()
        {
            new Teacher(){
                Id = 1,
                Name = "Prof Joao"
            },
            new Teacher(){
                Id = 2,
                Name = "Prof Pedro"
            },
            new Teacher(){
                Id = 3,
                Name = "Prof Maria"
            },
            new Teacher(){
                Id = 4,
                Name = "Prof Lucas"
            },
        };
        // GET: api/<TeacherController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Teachers);
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var teacher = Teachers.FirstOrDefault(a => a.Id == id);
            if (teacher == null)
            {
                return BadRequest();
            }
            return Ok(teacher);
        }

        // POST api/<TeacherController>
        [HttpPost]
        public IActionResult Post(Teacher teacher)
        {
            return Ok(teacher);
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Teacher teacher)
        {
            return Ok(teacher);
        }

        // PATCH api/<TeacherController>/5
        [HttpPut("{id}")]
        public IActionResult Patch(int id, Teacher teacher)
        {
            return Ok(teacher);
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
