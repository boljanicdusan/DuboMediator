using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Contracts.Persistence;
using DuboMediator.Application.Features.Courses.DTOs;
using DuboMediator.Application.Features.Courses.Requests.Commands;
using DuboMediator.Application.Sessions;
using AutoMapper;
using DuboMediator.Domain.Entities;
using MediatR;

namespace DuboMediator.Application.Features.Courses.Handlers.Commands
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _unitOfWork.CourseRepository.Get(request.UpdateCourseDto.Id);

            _mapper.Map<UpdateCourseDto, Course>(request.UpdateCourseDto, course);

            await _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}