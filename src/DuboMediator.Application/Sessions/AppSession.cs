using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuboMediator.Application.Sessions
{
    public class AppSession
    {
        public Guid? UserId { get; set; }
        public bool IsAuthor { get; set; }
        public List<string> Roles { get; set; }
    }
}