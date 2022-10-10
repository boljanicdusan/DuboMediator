using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Contracts.Persistence;
using DuboMediator.Application.Features.Courses.Requests.Commands;
using DuboMediator.Application.Sessions;
using AutoMapper;
using MediatR;

namespace DuboMediator.Application.Features.Courses.Handlers.Commands
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _unitOfWork.CourseRepository.Get(request.Id);

            if (course == null)
            {
                throw new Exception();
            }

            await _unitOfWork.CourseRepository.Delete(course);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}