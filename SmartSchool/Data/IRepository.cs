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
        Student[] GetAllStudents(bool includeTeacher = false);
        Student[] GetAllStudentsByDisciplineId(int disciplineId, bool includeTeacher = false);
        Student GetStudentById(int studentId, bool includeTeacher = false);

        //Teacher
        Teacher[] GetAllTeachers(bool includeStudent = false);
        Teacher[] GetAllTeacherByDisciplineId(int disciplineId, bool includeStudent = false);
        Teacher GetTeacherId(int teacherId, bool includeTeacher = false);

        void Add<T>(T entity)where T: class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();
    }
}
