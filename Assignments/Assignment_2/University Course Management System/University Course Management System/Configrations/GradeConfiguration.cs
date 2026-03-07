using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using University_Course_Management_System.Entities;

namespace University_Course_Management_System.Configrations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(g => g.Id);

            builder.HasOne(g => g.Assignment)
                   .WithMany()
                   .HasForeignKey(g => g.AssignmentId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(g => g.Student)
                   .WithMany(u => u.Grades)
                   .HasForeignKey(g => g.StudentId)
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
