using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Domain.Entities;

namespace DuboMediator.Application.UnitTests.Mocks
{
    public static class MockData
    {
        public static List<ApplicationUser> Users = new List<ApplicationUser>
        {
            new ApplicationUser
            {
                Id = Guid.Parse("7209b20c-4aef-402f-b0f7-49371274a492"),
                FirstName = "Dusan",
                LastName = "Teacher",
                Email = "dusanteacher@gmail.com",
                NormalizedEmail = "DUSANTEACHER@GMAIL.COM",
                UserName = "dusanteacher@gmail.com",
                NormalizedUserName = "DUSANTEACHER@GMAIL.COM",
                EmailConfirmed = true
            },
            new ApplicationUser
            {
                Id = Guid.Parse("6fc52f42-f970-4834-9225-a44a841f8c50"),
                FirstName = "Cris",
                LastName = "Teacher",
                Email = "cristeacher@gmail.com",
                NormalizedEmail = "CRISTEACHER@GMAIL.COM",
                UserName = "cristeacher@gmail.com",
                NormalizedUserName = "CRISTEACHER@GMAIL.COM",
                EmailConfirmed = true
            },
            new ApplicationUser
            {
                Id = Guid.Parse("16426261-70ef-44ef-920e-bb222af0e443"),
                FirstName = "Ana",
                LastName = "Student",
                Email = "anastudent@gmail.com",
                NormalizedEmail = "ANASTUDENT@GMAIL.COM",
                UserName = "anastudent@gmail.com",
                NormalizedUserName = "ANASTUDENT@GMAIL.COM",
                EmailConfirmed = true
            }
        };

        public static List<Course> Courses = new List<Course>
        {
            new Course
            {
                Id = Guid.Parse("b025cc86-0e27-4153-84c9-4899c168d005"),
                Name = "DESIGN PATTERNS",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi.",
                Topic = "C#",
                Price = 100,
                AuthorId = Guid.Parse("7209b20c-4aef-402f-b0f7-49371274a492")
            },
            new Course
            {
                Id = Guid.Parse("718e0c4d-20ce-4cc1-bcf6-f6acfff75e01"),
                Name = "DOTNET CORE 6",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi.",
                Topic = "C#",
                Price = 180,
                AuthorId = Guid.Parse("7209b20c-4aef-402f-b0f7-49371274a492")
            },
            new Course
            {
                Id = Guid.Parse("20c5bbcc-6efa-4eca-ab4a-d1226b3bb986"),
                Name = "SOLID and CLEAN ARCHITECTURE",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi.",
                Topic = ".net",
                Price = 180,
                AuthorId = Guid.Parse("6fc52f42-f970-4834-9225-a44a841f8c50")
            }
        };

        
    }
}