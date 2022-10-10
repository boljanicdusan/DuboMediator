using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuboMediator.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository CourseRepository { get; }
        ILectureRepository LectureRepository { get; }
        Task SaveChangesAsync();
    }
}