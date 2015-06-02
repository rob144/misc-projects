using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityLMS.Models
{
    public class Student
    {
        [Display(Name = "Student ID")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }

        [Display(Name = "Photo")]
        [UIHint("StudentPhoto")]
        public string Photo { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstMidName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(100)]
        public string EmailAddress { get; set; }

        [Display(Name = "Enrollment Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public string FullName()
        {
            return this.FirstMidName + " " + this.LastName;
        }
    }
}