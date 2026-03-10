using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using University.Data.ClassMappings;
using University.Data.Entities;

namespace University.Data.AppDbContext
{
    public class UniversityDbContext(DbContextOptions<UniversityDbContext> options) : DbContext(options)
    {
        DbSet<Student> students;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentMapping());

            modelBuilder.Entity<Student>().HasData(new List<Student>
            {
                new() { Id = 1, Name = "Ismaeel-Moussa" , Email = "ismaeel.moussa1@gmail.com" },
                new() { Id = 2, Name = "Abdulsalam-Fateh" , Email = "fatehabdalsalam@gmail.com" },
                new() { Id = 3, Name = "Ahmad-Thaer-Ater" , Email = "aeter520@gmail.com" },
                new() { Id = 4, Name = "Ihap-Abuwarda" , Email = "ihababuwardah@gmail.com" },
                new() { Id = 5, Name = "Muhammed-Elrimi" , Email = "mohamadrimi12345@gmail.com" },
                new() { Id = 6, Name = "Wasem-Alhariri" , Email = "wasemalhariri13@gmail.com" }
                
            });

       
        }
    }
}
