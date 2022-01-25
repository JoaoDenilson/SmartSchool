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

        public Student[] GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Student[] GetAllStudentsByDisciplineId()
        {
            throw new NotImplementedException();
        }

        public Student[] GetStudentId()
        {
            throw new NotImplementedException();
        }

        public Teacher[] GetAllTeachers()
        {
            throw new NotImplementedException();
        }

        public Teacher[] GetAllTeacherByDisciplineId()
        {
            throw new NotImplementedException();
        }

        public Teacher[] GetTeachertId()
        {
            throw new NotImplementedException();
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
