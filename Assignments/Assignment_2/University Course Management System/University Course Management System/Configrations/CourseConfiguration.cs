using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using University_Course_Management_System.Entities;

namespace University_Course_Management_System.Configrations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CourseName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.StartDate)
                   .IsRequired();

            builder.Property(c => c.EndDate)
                   .IsRequired();

            builder.HasMany(c => c.Assignments)
                   .WithOne(a => a.Course)
                   .HasForeignKey(a => a.CourseId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Syllabus)
                   .WithMany()
                   .HasForeignKey(c => c.SyllabusId)
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
