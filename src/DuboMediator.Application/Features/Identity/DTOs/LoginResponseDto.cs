using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuboMediator.Application.Features.Identity.DTOs
{
    public class LoginResponseDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}