using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Contracts.Persistence;
using DuboMediator.Domain.Entities;
using Moq;

namespace DuboMediator.Application.UnitTests.Mocks
{
    public static class MockCourseRepository
    {
        public static Mock<ICourseRepository> GetCourseRepository()
        {
            var mockRepository = new Mock<ICourseRepository>();

            // Get All
            mockRepository.Setup(r => r.GetAll()).ReturnsAsync(MockData.Courses);

            // Get By Id
            mockRepository.Setup(r => r.Get(It.IsAny<Guid>())).ReturnsAsync((Guid id) => MockData.Courses.FirstOrDefault(c => c.Id == id));

            // Create
            mockRepository.Setup(r => r.Add(It.IsAny<Course>())).ReturnsAsync((Course course) =>
            {
                MockData.Courses.Add(course);
                return course;
            });

            // Update

            // Delete

            return mockRepository;
        }
    }
}