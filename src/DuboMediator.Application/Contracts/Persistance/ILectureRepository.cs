using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Domain.Entities;

namespace DuboMediator.Application.Contracts.Persistence
{
    public interface ILectureRepository : IRepository<Lecture>
    {
        
    }
}