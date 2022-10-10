using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Features.Courses.DTOs;
using MediatR;

namespace DuboMediator.Application.Features.Courses.Requests.Queries
{
    public class GetCoursesQuery : IRequest<List<CourseListDto>>
    {
        
    }
}