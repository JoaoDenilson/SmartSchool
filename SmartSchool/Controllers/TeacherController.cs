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

namespace SmartSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        public readonly IRepository _repo;

        public readonly IMapper _mapper;

        public TeacherController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/<TeacherController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllTeachers(true);

            return Ok(_mapper.Map<IEnumerable<TeacherDto>>(result));
        }

        // GET api/<TeacherController>/5
        [HttpGet("byId/{id}")]
        public IActionResult Get(int id)
        {
            var teacher = _repo.GetTeacherId(id, true);
            if (teacher == null)
            {
                return BadRequest("Professor não encontrado.");
            }

            var teacherDto = _mapper.Map<StudentDto>(teacher);

            return Ok(teacherDto);
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
        public IActionResult Post(TeacherRegisterDto model)
        {
            var teacher = _mapper.Map<Teacher>(model);

            _repo.Add(teacher);
            if (_repo.SaveChanges())
            {
                return Created($"/api/teacher/{model.Id}", _mapper.Map<TeacherDto>(teacher));
            }
            return BadRequest("Professor não cadastrado");
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, TeacherRegisterDto model)
        {
            var teacher = _repo.GetTeacherId(id, false);
            if (teacher == null) return BadRequest("Professor não encontrado");

            _mapper.Map(model, teacher);

            _repo.Update(teacher);
            if (_repo.SaveChanges())
            {
                return Created($"/api/teacher/{model.Id}", _mapper.Map<TeacherDto>(teacher));
            }
            return BadRequest("Professor não atualizado");
        }

        // PATCH api/<TeacherController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, TeacherRegisterDto model)
        {
            var teacher = _repo.GetTeacherId(id, false);
            if (teacher == null) return BadRequest("Professor não encontrado");

            _mapper.Map(model, teacher);

            _repo.Update(teacher);
            if (_repo.SaveChanges())
            {
                return Created($"/api/teacher/{model.Id}", _mapper.Map<TeacherDto>(teacher));
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
