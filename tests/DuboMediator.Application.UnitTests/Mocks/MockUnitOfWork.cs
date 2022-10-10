using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Contracts.Persistence;
using Moq;

namespace DuboMediator.Application.UnitTests.Mocks
{
    public class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockCourseRepository = MockCourseRepository.GetCourseRepository();

            mockUow.Setup(r => r.CourseRepository).Returns(mockCourseRepository.Object);

            return mockUow;
        }
    }
}