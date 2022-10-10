using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Contracts.Persistence;
using DuboMediator.Domain.Entities;

namespace DuboMediator.Persistence.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(DuboMediatorDbContext context) : base(context)
        { }

    }
}