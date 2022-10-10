using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DuboMediator.Persistence.Configuration
{
    public class CoursesConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasOne(course => course.Author)
                .WithMany(user => user.AuthorCourses)
                .HasForeignKey(course => course.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasMany(course => course.Users)
                .WithMany(user => user.Courses)
                .UsingEntity(j => j.ToTable("UserCourses"));

            // builder.HasData(
            //     new Course
            //     {
            //         Id = Guid.Parse("b025cc86-0e27-4153-84c9-4899c168d005"),
            //         Name = "DESIGN PATTERNS",
            //         Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi.",
            //         Topic = "C#",
            //         Price = 100,
            //         AuthorId = Guid.Parse("7209b20c-4aef-402f-b0f7-49371274a492")
            //     },
            //     new Course
            //     {
            //         Id = Guid.Parse("718e0c4d-20ce-4cc1-bcf6-f6acfff75e01"),
            //         Name = "DOTNET CORE 6",
            //         Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi.",
            //         Topic = "C#",
            //         Price = 180,
            //         AuthorId = Guid.Parse("7209b20c-4aef-402f-b0f7-49371274a492")
            //     },
            //     new Course
            //     {
            //         Id = Guid.Parse("20c5bbcc-6efa-4eca-ab4a-d1226b3bb986"),
            //         Name = "SOLID and CLEAN ARCHITECTURE",
            //         Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi.",
            //         Topic = ".net",
            //         Price = 180,
            //         AuthorId = Guid.Parse("6fc52f42-f970-4834-9225-a44a841f8c50")
            //     }
            // );
        }
    }
}