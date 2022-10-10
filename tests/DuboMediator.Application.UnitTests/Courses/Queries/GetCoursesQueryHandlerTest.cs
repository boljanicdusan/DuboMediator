using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Features.Courses.DTOs;
using DuboMediator.Application.Features.Courses.Handlers.Queries;
using DuboMediator.Application.Features.Courses.Requests.Queries;
using Shouldly;
using Xunit;

namespace DuboMediator.Application.UnitTests.Courses.Queries
{
    public class GetCoursesQueryHandlerTest : CourseTestBase
    {
        [Fact]
        public async Task GetCourseRequestTest()
        {
            var handler = new GetCoursesQueryHandler(_mockUow.Object, _mapper);

            var result = await handler.Handle(new GetCoursesQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CourseListDto>>();
            result.Count.ShouldBe(3);
        }
    }
}