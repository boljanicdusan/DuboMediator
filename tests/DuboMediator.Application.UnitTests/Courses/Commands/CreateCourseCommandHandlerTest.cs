using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Features.Courses.Handlers.Commands;
using DuboMediator.Application.Features.Courses.Requests.Commands;
using Shouldly;
using Xunit;

namespace DuboMediator.Application.UnitTests.Courses.Commands
{
    public class CreateCourseCommandHandlerTest : CourseTestBase
    {
        [Fact]
        public async Task CreateCourseCommandTest()
        {
            var handler = new CreateCourseCommandHandler(_mockUow.Object, _mapper, _session);

            var result = await handler.Handle(new CreateCourseCommand(), CancellationToken.None);

            result.ShouldBeOfType<Guid>();

        }
    }
}