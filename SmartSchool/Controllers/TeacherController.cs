using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Data;
using SmartSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        public readonly IRepository _repo;

        public TeacherController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<TeacherController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllTeachers(true);
            return Ok(result);
        }

        // GET api/<TeacherController>/5
        [HttpGet("byId/{id}")]
        public IActionResult Get(int id)
        {
            var teacher = _repo.GetTeacherId(id, true);
            if (teacher == null)
            {
                return BadRequest();
            }
            return Ok(teacher);
        }

        // GET api/<StudentController>/5
        //[HttpGet("ByName")]
        //public IActionResult GetByName(string name)
        //{
        //    var teacher = _context.Teachers.FirstOrDefault(s =>
        //        s.Name.Contains(name)
        //    );
        //    if (teacher == null)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(teacher);
        //}

        // POST api/<TeacherController>
        [HttpPost]
        public IActionResult Post(Teacher teacher)
        {
            _repo.Add(teacher);
            if (_repo.SaveChanges())
            {
                return Ok(teacher);
            }
            return BadRequest("Professor não cadastrado");
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Teacher teacher)
        {
            var th = _repo.GetTeacherId(id, false);
            if (th == null) return BadRequest("Professor não encontrado");

            _repo.Update(teacher);
            if (_repo.SaveChanges())
            {
                return Ok(teacher);
            }
            return BadRequest("Professor não atualizado");
        }

        // PATCH api/<TeacherController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Teacher teacher)
        {
            var th = _repo.GetTeacherId(id, false);
            if (th == null) return BadRequest("Professor não encontrado");

            _repo.Update(teacher);
            if (_repo.SaveChanges())
            {
                return Ok(teacher);
            }
            return BadRequest("Professor não atualizado");
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teacher = _repo.GetTeacherId(id, false);
            if (teacher == null) return BadRequest("Professor não encontrado");

            _repo.Delete(teacher);
            if (_repo.SaveChanges())
            {
                return Ok("Professor deletado");
            }
            return BadRequest("Professor não deletado");
        }
    }
}
