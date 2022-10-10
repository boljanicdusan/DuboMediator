using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Contracts.Infrastructure.Identity;
using DuboMediator.Application.Features.Identity.DTOs;
using DuboMediator.Application.Features.Identity.Requests.Commands;
using MediatR;

namespace DuboMediator.Application.Features.Identity.Handlers.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponseDto>
    {
        private readonly IAccountService _accountService;

        public RegisterCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<RegisterResponseDto> Handle(RegisterCommand request, CancellationToken token)
        {
            return await _accountService.Register(request.RegisterRequestDto);
        }
    }
}