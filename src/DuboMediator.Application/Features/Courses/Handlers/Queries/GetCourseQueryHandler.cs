using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Contracts.Persistence;
using DuboMediator.Application.Features.Courses.DTOs;
using DuboMediator.Application.Features.Courses.Requests.Queries;
using AutoMapper;
using MediatR;

namespace DuboMediator.Application.Features.Courses.Handlers.Queries
{
    public class GetCourseQueryHandler : IRequestHandler<GetCourseQuery, CourseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCourseQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<CourseDto> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            var course = await _unitOfWork.CourseRepository.Get(request.Id);
            return _mapper.Map<CourseDto>(course);
        }
    }
}