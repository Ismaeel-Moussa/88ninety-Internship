using System;
using System.Collections.Generic;
using System.Text;

namespace University_Course_Management_System.Entities
{
    public class Course
    {
        public int Id { get; set; }

        public string CourseName { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }


        // navigations properties 
        public int TeacherId { get; set; }
        public User Teacher { get; set; } = null!;

        public int SyllabusId { get; set; }
        public Syllabus Syllabus { get; set; } = null!;

        public ICollection<Assignment> Assignments { get; set; } = [];
    }
}
