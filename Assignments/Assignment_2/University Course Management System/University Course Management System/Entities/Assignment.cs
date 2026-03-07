using System;
using System.Collections.Generic;
using System.Text;

namespace University_Course_Management_System.Entities
{
    public class Assignment
    {
        public int Id { get; set; }

        public string AssignmentTitle { get; set; } = string.Empty;

        public string? Description { get; set; }

        public float Weight { get; set; }

        public int MaxGrade { get; set; }

        public DateTime DueDate { get; set; }


        // navigations properties 
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public ICollection<Comment> Comments { get; set; } = [];
    }
}
