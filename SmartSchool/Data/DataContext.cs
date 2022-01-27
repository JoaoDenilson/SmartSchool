using Microsoft.EntityFrameworkCore;
using SmartSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<StudentDiscipline> StudentsDiscipline { get; set; }

        public DbSet<StudentCourse> StudentsCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentDiscipline>()
                .HasKey(SD => new { SD.StudentId, SD.DisciplineId });

            builder.Entity<Teacher>()
                .HasData(new List<Teacher>(){
                    new Teacher(1, 1, "Lauro", "Oliveira"),
                    new Teacher(2, 2, "Roberto", "Soares"),
                    new Teacher(3, 3, "Ronaldo", "Marconi"),
                    new Teacher(4, 4, "Rodrigo", "Carvalho"),
                    new Teacher(5, 5, "Alexandre", "Montanha"),
                });

            builder.Entity<Course>()
                .HasData(new List<Course>{
                    new Course(1, "Tecnologia da Informação"),
                    new Course(2, "Sistemas de Informação"),
                    new Course(3, "Ciência da Computação")
                });

            builder.Entity<Discipline>()
                .HasData(new List<Discipline>{
                    new Discipline(1, "Matemática", 1, 1),
                    new Discipline(2, "Matemática", 1, 3),
                    new Discipline(3, "Física", 2, 3),
                    new Discipline(4, "Português", 3, 1),
                    new Discipline(5, "Inglês", 4, 1),
                    new Discipline(6, "Inglês", 4, 2),
                    new Discipline(7, "Inglês", 4, 3),
                    new Discipline(8, "Programação", 5, 1),
                    new Discipline(9, "Programação", 5, 2),
                    new Discipline(10, "Programação", 5, 3)
                });

            builder.Entity<Student>()
                .HasData(new List<Student>(){
                    new Student(1, 1, "Marta", "Kent", "33225555", DateTime.Parse("05/28/2005")),
                    new Student(2, 2, "Paula", "Isabela", "3354288", DateTime.Parse("05/28/2005")),
                    new Student(3, 3, "Laura", "Antonia", "55668899", DateTime.Parse("05/28/2005")),
                    new Student(4, 4, "Luiza", "Maria", "6565659", DateTime.Parse("05/28/2005")),
                    new Student(5, 5, "Lucas", "Machado", "565685415", DateTime.Parse("05/28/2005")),
                    new Student(6, 6, "Pedro", "Alvares", "456454545", DateTime.Parse("05/28/2005")),
                    new Student(7, 7, "Paulo", "José", "9874512", DateTime.Parse("05/28/2005"))
                });

            builder.Entity<StudentDiscipline>()
                .HasData(new List<StudentDiscipline>() {
                    new StudentDiscipline() {StudentId = 1, DisciplineId = 2 },
                    new StudentDiscipline() {StudentId = 1, DisciplineId = 4 },
                    new StudentDiscipline() {StudentId = 1, DisciplineId = 5 },
                    new StudentDiscipline() {StudentId = 2, DisciplineId = 1 },
                    new StudentDiscipline() {StudentId = 2, DisciplineId = 2 },
                    new StudentDiscipline() {StudentId = 2, DisciplineId = 5 },
                    new StudentDiscipline() {StudentId = 3, DisciplineId = 1 },
                    new StudentDiscipline() {StudentId = 3, DisciplineId = 2 },
                    new StudentDiscipline() {StudentId = 3, DisciplineId = 3 },
                    new StudentDiscipline() {StudentId = 4, DisciplineId = 1 },
                    new StudentDiscipline() {StudentId = 4, DisciplineId = 4 },
                    new StudentDiscipline() {StudentId = 4, DisciplineId = 5 },
                    new StudentDiscipline() {StudentId = 5, DisciplineId = 4 },
                    new StudentDiscipline() {StudentId = 5, DisciplineId = 5 },
                    new StudentDiscipline() {StudentId = 6, DisciplineId = 1 },
                    new StudentDiscipline() {StudentId = 6, DisciplineId = 2 },
                    new StudentDiscipline() {StudentId = 6, DisciplineId = 3 },
                    new StudentDiscipline() {StudentId = 6, DisciplineId = 4 },
                    new StudentDiscipline() {StudentId = 7, DisciplineId = 1 },
                    new StudentDiscipline() {StudentId = 7, DisciplineId = 2 },
                    new StudentDiscipline() {StudentId = 7, DisciplineId = 3 },
                    new StudentDiscipline() {StudentId = 7, DisciplineId = 4 },
                    new StudentDiscipline() {StudentId = 7, DisciplineId = 5 }
                });
        }
    }
}
