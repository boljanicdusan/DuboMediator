using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Contracts.Persistence;
using DuboMediator.Application.Features.Courses.Requests.Commands;
using DuboMediator.Application.Sessions;
using AutoMapper;
using DuboMediator.Domain.Entities;
using MediatR;

namespace DuboMediator.Application.Features.Courses.Handlers.Commands
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AppSession _session;

        public CreateCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, AppSession session)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _session = session;
        }

        public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = _mapper.Map<Course>(request.CreateCourseDto);

            course.AuthorId = (Guid)_session.UserId;

            await _unitOfWork.CourseRepository.Add(course);
            await _unitOfWork.SaveChangesAsync();

            return course.Id;
        }
    }
}