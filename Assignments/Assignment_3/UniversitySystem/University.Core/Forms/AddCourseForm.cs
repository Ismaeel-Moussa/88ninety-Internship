

using System.ComponentModel.DataAnnotations;

namespace University.Core.Forms
{
    public class AddCourseForm
    {
        [Required]
        public string Name { get; set; }
         
        [Required]
        [Range(1, 10)]
        public byte Credit { get; set; }


    }
}
