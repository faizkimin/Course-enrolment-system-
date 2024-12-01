using System;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required]
        [MaxLength(100)]
        public string StudentNo { get; set; }

        [Required]
        [MaxLength(100)]
        public string StudentName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string StudentEmail { get; set; }

        [Required]
        [MaxLength(100)]
        public string StudentContactNumber { get; set; }

        public DateOnly StudentEnrollmentDate { get; set; }
    }
}