using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Contracts.Infrastructure.Identity;
using DuboMediator.Application.Features.Identity.DTOs;
using DuboMediator.Application.Features.Identity.Requests.Queries;
using MediatR;

namespace DuboMediator.Application.Features.Identity.Handlers.Commands
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponseDto>
    {
        private readonly IAccountService _accountService;

        public LoginQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        
        public async Task<LoginResponseDto> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            return await _accountService.Login(request.LoginRequestDto);
        }
    }
}