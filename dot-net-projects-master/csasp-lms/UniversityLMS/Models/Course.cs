using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityLMS.Models
{
    public class Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { get; set; }

        [Display(Name ="Course Code")]
        [Required]
        public string CourseIDExternal { get; set; }

        [Required]
        public string Title { get; set; }

        public int Credits { get; set; }

        [Display(Name = "Date Created")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        public DateTime DateCreated { get; set; }

        [UIHint("CourseInstructors")]
        public virtual ICollection<Instructor> Instructors { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}