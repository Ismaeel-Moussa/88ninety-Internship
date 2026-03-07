using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using University_Course_Management_System.Configrations;
using University_Course_Management_System.Entities;

namespace University_Course_Management_System.DataAccess
{
    public class UniversityDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Syllabus> Syllabi { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new AssignmentConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new GradeConfiguration());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;Database=UniversityDB;User Id=sa;Password=sa123456;TrustServerCertificate=True");
        }


    }
}
