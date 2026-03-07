using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using University_Course_Management_System.Entities;

namespace University_Course_Management_System.Configrations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CommentContent)
                   .IsRequired();

            builder.HasOne(c => c.Assignment)
                   .WithMany(a => a.Comments)
                   .HasForeignKey(c => c.AssignmentId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.User)
                   .WithMany(u => u.Comments)
                   .HasForeignKey(c => c.CreatedByUserId)
                   .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
