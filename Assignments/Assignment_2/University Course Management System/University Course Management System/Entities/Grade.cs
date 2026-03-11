using System;
using System.Collections.Generic;
using System.Text;

namespace University_Course_Management_System.Entities
{
    public class Grade
    {
        public int Id { get; set; }
        public int Mark { get; set; }


        // navigations properties 

        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; } = null!;

        public int StudentId { get; set; }
        public User Student { get; set; } = null!;


    }
}
