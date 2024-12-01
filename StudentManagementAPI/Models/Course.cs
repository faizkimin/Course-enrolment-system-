using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        [Required]
        [MaxLength(100)]
        public string CourseCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string CourseName { get; set; }


    }
}
