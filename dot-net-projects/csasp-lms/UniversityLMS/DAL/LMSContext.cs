using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using UniversityLMS.Models;

namespace UniversityLMS.DAL
{
    public class LMSContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Instructor> Instructors { get; set; }

        
    }
}