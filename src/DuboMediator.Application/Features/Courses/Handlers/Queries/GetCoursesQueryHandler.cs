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
    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, List<CourseListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public GetCoursesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<List<CourseListDto>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _unitOfWork.CourseRepository.GetAll();
            return _mapper.Map<List<CourseListDto>>(courses);
        }
    }
}