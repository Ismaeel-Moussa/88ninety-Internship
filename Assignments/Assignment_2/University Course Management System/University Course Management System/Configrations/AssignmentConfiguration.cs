using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using University_Course_Management_System.Entities;

namespace University_Course_Management_System.Configrations
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.AssignmentTitle)
                   .IsRequired()
                   .HasMaxLength(128);

            builder.Property(a => a.DueDate)
                   .IsRequired();

            builder.HasOne(a => a.Course)
                   .WithMany(c => c.Assignments)
                   .HasForeignKey(a => a.CourseId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.Comments)
                    .WithOne(c => c.Assignment)
                    .HasForeignKey(c => c.AssignmentId)
                    .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
