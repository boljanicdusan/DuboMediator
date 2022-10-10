using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuboMediator.Application.Features.Courses.DTOs
{
    public class CreateCourseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Topic { get; set; }
        public double Price { get; set; }
    }
}