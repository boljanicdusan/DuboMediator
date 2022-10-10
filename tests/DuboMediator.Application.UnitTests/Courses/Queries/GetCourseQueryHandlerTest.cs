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
    public class GetCourseQueryHandlerTest: CourseTestBase
    {
        [Fact]
        public async Task GetCourseRequestTest()
        {
            var handler = new GetCourseQueryHandler(_mockUow.Object, _mapper);

            var result = await handler.Handle(new GetCourseQuery(Guid.Parse("b025cc86-0e27-4153-84c9-4899c168d005")), CancellationToken.None);

            result.ShouldBeOfType<CourseDto>();
            result.Name.ShouldBe("DESIGN PATTERNS");
        }
    }
}