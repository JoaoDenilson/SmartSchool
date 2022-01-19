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
    public class StudentController : ControllerBase
    {
        private readonly DataContext _context;
        public readonly IRepository _repo;

        public StudentController(DataContext context,
                                 IRepository repo)
        {
            _repo = repo;
            _context = context;
        }

        [HttpGet("pegaResposta")]
        public IActionResult pegaResposta()
        {
            return Ok("ok");
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Students);
        }

        // GET api/<StudentController>/5
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var student = _context.Students.FirstOrDefault(a => a.Id == id);
            if (student == null)
            {
                return BadRequest();
            }
            return Ok(student);
        }

        // GET api/<StudentController>/5
        [HttpGet("ByName")]
        public IActionResult GetByName(string name, string lastName)
        {
            var student = _context.Students.FirstOrDefault(a => 
                a.Name.Contains(name) && a.LastName.Contains(lastName)
            );
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
            _context.Add(student);
            _context.SaveChanges();
            return Ok(student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            var st = _context.Students.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (st == null) return BadRequest("Estudante não encontrado");

            _context.Update(student);
            _context.SaveChanges();
            return Ok(student);
        }

        // PATCH api/<StudentController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Student student)
        {
            var st = _context.Students.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (st == null) return BadRequest("Estudante não encontrado");

            _context.Update(student);
            _context.SaveChanges();
            return Ok(student);
        }
        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(a => a.Id == id);
            if (student == null) return BadRequest("Estudante não encontrado");

            _context.Remove(student);
            _context.SaveChanges();
            return Ok();
        }
    }
}
