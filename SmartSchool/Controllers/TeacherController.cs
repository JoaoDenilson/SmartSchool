using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Data;
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
        private readonly DataContext _context;

        public TeacherController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<TeacherController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Teachers);
        }

        // GET api/<TeacherController>/5
        [HttpGet("byId/{id}")]
        public IActionResult Get(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(a => a.Id == id);
            if (teacher == null)
            {
                return BadRequest();
            }
            return Ok(teacher);
        }

        // GET api/<StudentController>/5
        [HttpGet("ByName")]
        public IActionResult GetByName(string name)
        {
            var teacher = _context.Teachers.FirstOrDefault(s =>
                s.Name.Contains(name)
            );
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
            _context.Add(teacher);
            _context.SaveChanges();
            return Ok(teacher);
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Teacher teacher)
        {
            var th = _context.Teachers.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (th == null) return BadRequest("Professor não encontrado");

            _context.Update(teacher);
            _context.SaveChanges();
            return Ok(teacher);
        }

        // PATCH api/<TeacherController>/5
        [HttpPut("{id}")]
        public IActionResult Patch(int id, Teacher teacher)
        {
            var th = _context.Teachers.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (th == null) return BadRequest("Professor não encontrado");

            _context.Update(teacher);
            _context.SaveChanges();
            return Ok(teacher);
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(a => a.Id == id);
            if (teacher == null) return BadRequest("Professor não encontrado");

            _context.Remove(teacher);
            _context.SaveChanges();
            return Ok();
        }
    }
}
