using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Consts;
using DuboMediator.Application.Features.Courses.DTOs;
using DuboMediator.Application.Features.Courses.Requests.Commands;
using DuboMediator.Application.Features.Courses.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DuboMediator.API.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : DuboMediatorBaseController
    {
        private readonly IMediator _mediator;

        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseListDto>>> Get()
        {
            var courses = await _mediator.Send(new GetCoursesQuery());
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<CourseListDto>>> Get(Guid id)
        {
            var courses = await _mediator.Send(new GetCourseQuery(id));
            return Ok(courses);
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.Author)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCourseDto createCourseDto)
        {
            var courseId = await _mediator.Send(new CreateCourseCommand { CreateCourseDto = createCourseDto });
            return Ok(courseId);
        }
    }
}