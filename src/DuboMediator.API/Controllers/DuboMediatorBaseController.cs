using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DuboMediator.API.FIlters;
using DuboMediator.Application.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DuboMediator.API.Controllers
{
    [Authorize]
    [ApiController]
    [SessionFilter]
    public class DuboMediatorBaseController : ControllerBase
    {
        public Guid? UserId
        {
            get
            {
                string userIdString = GetClaimValue(CustomClaims.Uid);
                if (Guid.TryParse(userIdString, out Guid userId))
                {
                    return userId;
                }

                return null;
                
            }
        }
        
        public string Email
        {
            get
            {
                return GetClaimValue(ClaimTypes.Email);
            }
        }

        public string FullName
        {
            get 
            {
                return GetClaimValue(ClaimTypes.Name);
            }
        }

        public bool IsAuthor
        {
            get
            {
                return Roles.Contains(RoleNames.Author);
            }
        }

        public List<string> Roles
        {
            get
            {
                var roles = GetClaimValues(ClaimTypes.Role);
                return roles ?? new List<string>();
            }
        }

        protected string GetClaimValue(string type)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var claim = claimsIdentity.Claims
                    .FirstOrDefault(c => c.Type == type);

                if (claim != null)
                {
                    return claim.Value;
                }
            }

            return null;
        }

        protected List<string> GetClaimValues(string type)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                return claimsIdentity.Claims
                    .Where(c => c.Type == type)
                    .Select(c => c.Value)
                    .ToList();
            }

            return null;
        }
    }
}