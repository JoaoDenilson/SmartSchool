using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Data;
using SmartSchool.Dtos;
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
        public readonly IRepository _repo;

        public readonly IMapper _mapper;

        public StudentController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public IActionResult Get()
        {
            var students = _repo.GetAllStudents(true);
            
            return Ok(_mapper.Map<IEnumerable<StudentDto>>(students));
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _repo.GetStudentById(id, false);
            if (student == null)
            {
                return BadRequest();
            }
            return Ok(student);
        }

        // GET api/<StudentController>/5
        //[HttpGet("ByName")]
        //public IActionResult GetByName(string name, string lastName)
        //{
        //    var student = _context.Students.FirstOrDefault(a => 
        //        a.Name.Contains(name) && a.LastName.Contains(lastName)
        //    );
        //    if (student == null)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(student);
        //}

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post(Student student)
        {
            _repo.Add(student);
            if (_repo.SaveChanges())
            {
                return Ok(student);
            }
            return BadRequest("Estudante não cadastrado.");
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            var st = _repo.GetStudentById(id);
            if (st == null) return BadRequest("Estudante não encontrado.");

            _repo.Update(student);
            if (_repo.SaveChanges())
            {
                return Ok(student);
            }
            return BadRequest("Estudante não atualizado.");
        }

        // PATCH api/<StudentController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Student student)
        {
            var st = _repo.GetStudentById(id);
            if (st == null) return BadRequest("Estudante não encontrado.");

            _repo.Update(student);
            if (_repo.SaveChanges())
            {
                return Ok(student);
            }
            return BadRequest("Estudante não atualizado.");
        }
        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _repo.GetStudentById(id);
            if (student == null) return BadRequest("Estudante não encontrado.");

            _repo.Delete(student);
            if (_repo.SaveChanges())
            {
                return Ok("Estudante deletado.");
            }
            return BadRequest("Estudante não deletado.");
        }
    }
}
