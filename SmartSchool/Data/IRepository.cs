using SmartSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Data
{
    public interface IRepository
    {
        //Student
        Student[] GetAllStudents();
        Student[] GetAllStudentsByDisciplineId();
        Student[] GetStudentId();

        //Teacher
        Teacher[] GetAllTeachers();
        Teacher[] GetAllTeacherByDisciplineId();
        Teacher[] GetTeachertId();

        void Add<T>(T entity)where T: class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();
    }
}
