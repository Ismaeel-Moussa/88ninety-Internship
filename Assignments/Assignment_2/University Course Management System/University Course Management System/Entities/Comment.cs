using System;
using System.Collections.Generic;
using System.Text;

namespace University_Course_Management_System.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentContent { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;


        // navigations properties 
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; } = null!;

        public int CreatedByUserId { get; set; }
        public User User { get; set; } = null!;


    }
}
