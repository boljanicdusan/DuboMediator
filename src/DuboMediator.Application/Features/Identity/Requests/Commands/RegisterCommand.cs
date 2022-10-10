using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Features.Identity.DTOs;
using MediatR;

namespace DuboMediator.Application.Features.Identity.Requests.Commands
{
    public class RegisterCommand : IRequest<RegisterResponseDto>
    {
        public RegisterRequestDto RegisterRequestDto { get; set; }
    }
}