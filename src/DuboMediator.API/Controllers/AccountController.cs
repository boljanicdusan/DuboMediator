using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Features.Identity.DTOs;
using DuboMediator.Application.Features.Identity.Requests.Commands;
using DuboMediator.Application.Features.Identity.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DuboMediator.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AccountController : DuboMediatorBaseController
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto request)
        {
            var loginResposne = await _mediator.Send(new LoginQuery { LoginRequestDto = request });
            return Ok(loginResposne);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegisterResponseDto>> Register([FromBody] RegisterRequestDto request)
        {
            var registerResposne = await _mediator.Send(new RegisterCommand { RegisterRequestDto = request });
            return Ok(registerResposne);
        }
    }
}