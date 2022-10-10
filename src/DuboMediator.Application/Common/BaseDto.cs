using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuboMediator.Application.Common
{
    public class BaseDto : BaseDto<Guid>
    {
        
    }
    
    public class BaseDto<T>
    {
        public T Id { get; set; }
    }
}