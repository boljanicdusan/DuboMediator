using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DuboMediator.Domain.Entities
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole() : base()
        {}

        public ApplicationRole(string roleName) : base(roleName) 
        {
            NormalizedName = roleName.ToUpper();
        }
    }
}