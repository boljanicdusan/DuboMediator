using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Features.Identity.DTOs;

namespace DuboMediator.Application.Contracts.Infrastructure.Identity
{
    public interface IAccountService
    {
        Task<LoginResponseDto> Login(LoginRequestDto request);
        Task<RegisterResponseDto> Register(RegisterRequestDto request);
    }
}