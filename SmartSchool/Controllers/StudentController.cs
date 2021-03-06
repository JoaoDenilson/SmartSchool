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
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public readonly IRepository _repo;
        public readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public StudentController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Método responsável por retornar todos os Alunos
        /// </summary>
        /// <returns></returns>
        // GET: api/<StudentController>
        [HttpGet]
        public IActionResult Get()
        {
            var students = _repo.GetAllStudents(true);
            
            return Ok(_mapper.Map<IEnumerable<StudentDto>>(students));
        }

        // GET api/<StudentController>
        /// <summary>
        /// Método responsável por retorna um Aluno por meio do ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _repo.GetStudentById(id, false);
            if (student == null)
            {
                return BadRequest("Estudante não encontrado.");
            }

            var studentDto = _mapper.Map<StudentDto>(student);

            return Ok(studentDto);
        }
        /// <summary>
        /// Método responsável por registar um Aluno
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(StudentRegisterDto model)
        {
            var student = _mapper.Map<Student>(model);

            _repo.Add(student);
            if (_repo.SaveChanges())
            {
                return Created($"/api/student/{model.Id}", _mapper.Map<StudentDto>(student));
            }
            return BadRequest("Estudante não cadastrado.");
        }

        // PUT api/<StudentController>/5
        /// <summary>
        /// Método responsável por atualizar um Aluno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, StudentRegisterDto model)
        {
            var student = _repo.GetStudentById(id);
            if (student == null) return BadRequest("Estudante não encontrado.");

            _mapper.Map(model, student);

            _repo.Update(student);
            if (_repo.SaveChanges())
            {
                return Created($"/api/student/{model.Id}", _mapper.Map<StudentDto>(student));
            }
            return BadRequest("Estudante não atualizado.");
        }

        // PATCH api/<StudentController>/5
        /// <summary>
        /// Método responsável por atualizar um ou varios dados de um Aluno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, StudentPatchDto model)
        {
            var student = _repo.GetStudentById(id);
            if (student == null) return BadRequest("Estudante não encontrado.");
            model.Id = id;

            _mapper.Map(model, student);

            _repo.Update(student);
            if (_repo.SaveChanges())
            {
                return Created($"/api/student/{model.Id}", _mapper.Map<StudentPatchDto>(student));
            }
            return BadRequest("Estudante não atualizado.");
        }
        // DELETE api/<StudentController>/5
        /// <summary>
        /// Método responsável por deletar um Aluno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
