using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Features.Courses.DTOs;
using AutoMapper;
using DuboMediator.Domain.Entities;

namespace DuboMediator.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Courses mapping
            CreateMap<Course, CourseDto>();
            CreateMap<Course, CourseListDto>();
            CreateMap<CreateCourseDto, Course>();
            CreateMap<UpdateCourseDto, Course>();
            #endregion 
            
        }
    }
}