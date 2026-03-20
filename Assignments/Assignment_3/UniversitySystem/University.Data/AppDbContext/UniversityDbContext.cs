using Microsoft.EntityFrameworkCore;
using University.Data.ClassMappings;
using University.Data.Entities;

namespace University.Data.AppDbContext
{
    public class UniversityDbContext(DbContextOptions<UniversityDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentMapping());
            modelBuilder.ApplyConfiguration(new CourseMapping());

            modelBuilder.Entity<Student>().HasData(new List<Student>
            {
                new() { Id = 1, Name = "Ismaeel-Moussa" , Email = "ismaeel.moussa1@gmail.com" },
                new() { Id = 2, Name = "Abdulsalam-Fateh" , Email = "fatehabdalsalam@gmail.com" },
                new() { Id = 3, Name = "Ahmad-Thaer-Ater" , Email = "aeter520@gmail.com" },
                new() { Id = 4, Name = "Ihap-Abuwarda" , Email = "ihababuwardah@gmail.com" },
                new() { Id = 5, Name = "Muhammed-Elrimi" , Email = "mohamadrimi12345@gmail.com" },
                new() { Id = 6, Name = "Wasem-Alhariri" , Email = "wasemalhariri13@gmail.com" }
                
            });

            modelBuilder.Entity<Course>().HasData(new List<Course>
            {
                new() { Id = 1, Name = "Mathematics" , Credit = 7 },
                new() { Id = 2, Name = "Physics" , Credit = 5 },
                new() { Id = 3, Name = "Chemistry" , Credit = 5 },
                new() { Id = 4, Name = "Biology" ,  Credit = 5},
                new() { Id = 5, Name = "Computer Science" , Credit = 5 },
                new() { Id = 6, Name = "English" ,  Credit = 3 }

            });


        }
    }
}
