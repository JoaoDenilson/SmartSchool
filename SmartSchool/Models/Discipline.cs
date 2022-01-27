﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Models
{
    public class Discipline
    {
        public Discipline() { }
        public Discipline(int id, string name, int teacherId, int courseId)
        {
            this.Id = id;
            this.Name = name;
            this.TeacherId = teacherId;
            this.CourseId = courseId;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Workload { get; set; }
        public int? PrerequisiteId { get; set; } = null;
        public Discipline Prerequisite { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public IEnumerable<StudentDiscipline> StudentsDiscipline { get; set; }
    }
}
