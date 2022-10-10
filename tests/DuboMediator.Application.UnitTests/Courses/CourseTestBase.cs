using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Consts;
using DuboMediator.Application.Contracts.Persistence;
using DuboMediator.Application.Profiles;
using DuboMediator.Application.Sessions;
using DuboMediator.Application.UnitTests.Mocks;
using AutoMapper;
using Moq;

namespace DuboMediator.Application.UnitTests.Courses
{
    public class CourseTestBase
    {
        protected readonly Mock<IUnitOfWork> _mockUow;
        protected readonly IMapper _mapper;
        protected readonly AppSession _session;

        public CourseTestBase()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            
            _session = new AppSession
            {
                UserId = Guid.Parse("7209b20c-4aef-402f-b0f7-49371274a492"),
                IsAuthor = true,
                Roles = new List<string> { RoleNames.Author }
            };

            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }
    }
}