using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Users.Models;

namespace Users.Infrastructure
{
    public class DocumentAuthorizatioRequirement : IAuthorizationRequirement
    {
        public bool AllowAuthors { get; set; }
        public bool AllowEditors { get; set; }
    }

    public class DocumentAuthorizationHandler : AuthorizationHandler<DocumentAuthorizatioRequirement>
    {

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DocumentAuthorizatioRequirement requirement)
        {
            ProtectedDocument document = context.Resource as ProtectedDocument;
            string user = context.User.Identity.Name;
            StringComparison compare = StringComparison.OrdinalIgnoreCase;
            if (document != null && user != null
                && (requirement.AllowAuthors&&document.Author.Equals(user,compare))||(requirement.AllowEditors&&document.Editor.Equals(user,compare)))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}