using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace DuboMediator.Application.Features.Courses.Requests.Commands
{
    public class DeleteCourseCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}