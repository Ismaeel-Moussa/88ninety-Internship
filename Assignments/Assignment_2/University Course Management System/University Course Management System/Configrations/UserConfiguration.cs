using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using University_Course_Management_System.Entities;

namespace University_Course_Management_System.Configrations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.EmailAddress).IsUnique();

            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(u => u.EmailAddress)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(u => u.PhoneNumber)
                .IsRequired()
                .HasMaxLength(16);

            builder.Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(32);

            builder.HasMany(u => u.Courses)
                .WithOne(c => c.Teacher)
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.CreatedByUserId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasMany(u => u.Grades)
                .WithOne(g => g.Student)
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
