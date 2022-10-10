using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Consts;
using DuboMediator.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DuboMediator.Persistence.Configuration
{
    public static class DuboMediatorDbContextSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<DuboMediatorDbContext>();
                var roleStore = new RoleStore<ApplicationRole, DuboMediatorDbContext, Guid>(context);
                var userStore = new UserStore<ApplicationUser, ApplicationRole, DuboMediatorDbContext, Guid>(context);
                var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

                // Create Roles
                string[] roles = new string[] { RoleNames.Author, RoleNames.Student };
                CreateRoles(roleStore, roles);

                // Create Users and Assign Roles
                var author = GetDefaultAuthor();
                var authorPassword = "123qwe!@#QWE";
                CreateUser(userStore, userManager, author, authorPassword);
                AssignRole(userManager, author.Email, RoleNames.Author);

                var student = GetDefaultStudent();
                var studentPassword = "123qwe!@#QWE";
                CreateUser(userStore, userManager, student, studentPassword);
                AssignRole(userManager, student.Email, RoleNames.Student);

                context.SaveChanges();
            }
        }

        private static void CreateRoles(RoleStore<ApplicationRole, DuboMediatorDbContext, Guid> roleStore, string[] roles)
        {
            foreach (string role in roles)
            {
                if (roleStore.Context.Roles.All(r => r.Name != role))
                {
                    var result = roleStore.CreateAsync(new ApplicationRole(role)).Result;
                }
            }
        }

        private static void CreateUser(UserStore<ApplicationUser, ApplicationRole, DuboMediatorDbContext, Guid> userStore, UserManager<ApplicationUser> userManager, ApplicationUser user, string password)
        {
            if (userStore.Context.Users.All(u => u.Id != user.Id))
            {
                var hasher = new PasswordHasher<ApplicationUser>();
                var hashed = hasher.HashPassword(user, password);
                user.PasswordHash = hashed;

                var result = userStore.CreateAsync(user).Result;
            }
        }

        private static IdentityResult AssignRole(UserManager<ApplicationUser> _userManager, string email, string role)
        {
            var user = _userManager.FindByEmailAsync(email).Result;
            var result = _userManager.AddToRoleAsync(user, role).Result;

            return result;
        }

        private static ApplicationUser GetDefaultAuthor()
        {
            return new ApplicationUser
            {
                Id = Guid.Parse("7209b20c-4aef-402f-b0f7-49371274a492"),
                FirstName = "Dusan",
                LastName = "Author",
                Email = "dusanauthor@gmail.com",
                NormalizedEmail = "DUSANAUTHOR@GMAIL.COM",
                UserName = "dusanauthor@gmail.com",
                NormalizedUserName = "DUSANAUTHOR@GMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                CreationTime = DateTime.UtcNow
            };
        }

        private static ApplicationUser GetDefaultStudent()
        {
            return new ApplicationUser
            {
                Id = Guid.Parse("16426261-70ef-44ef-920e-bb222af0e443"),
                FirstName = "Ana",
                LastName = "Student",
                Email = "anastudent@gmail.com",
                NormalizedEmail = "ANASTUDENT@GMAIL.COM",
                UserName = "anastudent@gmail.com",
                NormalizedUserName = "ANASTUDENT@GMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                CreationTime = DateTime.UtcNow
            };
        }
    }
}