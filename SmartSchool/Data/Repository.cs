using Microsoft.EntityFrameworkCore;
using SmartSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Data
{
    public class Repository : IRepository
    {
        private DataContext _context;

        public Repository(DataContext context) {
            _context = context;
        }

        public Student[] GetAllStudents(bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(a => a.StudentsDiscipline)
                                .ThenInclude(sd => sd.Discipline)
                                .ThenInclude(d => d.Teacher);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray();
        }

        public Student[] GetAllStudentsByDisciplineId(int disciplineId, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(a => a.StudentsDiscipline)
                             .ThenInclude(sd => sd.Discipline)
                             .ThenInclude(d => d.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(s => s.StudentsDiscipline.Any(ad => ad.DisciplineId == disciplineId));

            return query.ToArray();
        }

        public Student GetStudentById(int studentId, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(s => s.StudentsDiscipline)
                             .ThenInclude(sd => sd.Discipline)
                             .ThenInclude(d => d.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(s => s.Id)
                         .Where(s => s.Id == studentId);

            return query.FirstOrDefault();
        }

        public Teacher[] GetAllTeachers(bool includeStudent = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudent)
            {
                query = query.Include(t => t.Disciplines)
                             .ThenInclude(d => d.StudentsDiscipline)
                             .ThenInclude(sd => sd.Student);
            }

            query = query.AsNoTracking().OrderBy(t => t.Id);

            return query.ToArray();
        }

        public Teacher[] GetAllTeacherByDisciplineId(int disciplineId, bool includeStudent = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudent)
            {
                query = query.Include(t => t.Disciplines)
                             .ThenInclude(d => d.StudentsDiscipline)
                             .ThenInclude(sd => sd.Student);
            }

            query = query.AsNoTracking()
                         .OrderBy(s => s.Id)
                         .Where(s => s.Disciplines.Any(d => d.StudentsDiscipline.Any(sd => sd.DisciplineId == disciplineId)));

            return query.ToArray();
        }

        public Teacher GetTeacherId(int teacherId, bool includeTeacher = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeTeacher)
            {
                query = query.Include(t => t.Disciplines)
                             .ThenInclude(d => d.StudentsDiscipline)
                             .ThenInclude(sd => sd.Student);
            }

            query = query.AsNoTracking()
                         .OrderBy(s => s.Id)
                         .Where(t => t.Id == teacherId);

            return query.FirstOrDefault();
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

    
    }
}
