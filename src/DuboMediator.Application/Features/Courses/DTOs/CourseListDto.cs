using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Common;
using DuboMediator.Application.Features.Identity.DTOs;

namespace DuboMediator.Application.Features.Courses.DTOs
{
    public class CourseListDto : BaseDto
    {
        public string Name { get; set; }
        public string Topic { get; set; }
        public double Price { get; set; }
        public UserDto Author { get; set; }
    }
}