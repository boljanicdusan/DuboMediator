using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Features.Identity.DTOs;
using MediatR;

namespace DuboMediator.Application.Features.Identity.Requests.Queries
{
    public class LoginQuery : IRequest<LoginResponseDto>
    {
        public LoginRequestDto LoginRequestDto { get; set; }
    }
}