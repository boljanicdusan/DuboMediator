using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuboMediator.Domain.EntityBase
{
    public interface IAuditedEntity : IAuditCreating, IAuditUpdating, IAuditDeleting, ISoftDelete
    {
        
    }
}