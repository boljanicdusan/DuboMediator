using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.API.Controllers;
using DuboMediator.Application.Sessions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DuboMediator.API.FIlters
{
    public class SessionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var session = (AppSession)context.HttpContext.RequestServices.GetService((typeof(AppSession)));

            var userId = (context.Controller as DuboMediatorBaseController).UserId;
            var isAuthor = (context.Controller as DuboMediatorBaseController).IsAuthor;
            var roles = (context.Controller as DuboMediatorBaseController).Roles;

            session.UserId = userId;
            session.IsAuthor = isAuthor;
            session.Roles = roles;
        }
    }
}