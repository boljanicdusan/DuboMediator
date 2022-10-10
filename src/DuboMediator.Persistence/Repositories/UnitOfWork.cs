using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Contracts.Persistence;
using DuboMediator.Application.Sessions;

namespace DuboMediator.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DuboMediatorDbContext _context;
        private readonly AppSession _session;
        private ICourseRepository _courseRepository;
        private ILectureRepository _lectureRepository;

        public UnitOfWork(DuboMediatorDbContext cotnext, AppSession session)
        {
            _context = cotnext;
            _session = session;
        }
        
        public ICourseRepository CourseRepository => _courseRepository ??= new CourseRepository(_context);

        public ILectureRepository LectureRepository => _lectureRepository ??= new LectureRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            // GET USER ID
            var userId = _session.UserId?.ToString();
            await _context.SaveChangesAsync(userId);
        }
    }
}