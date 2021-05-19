using Microsoft.AspNetCore.Authorization;

namespace Users.Infrastructure
{
    public class DocumentAuthorizationRequirement : IAuthorizationRequirement
    {
        public bool AllowAuthors { get; set; }
        public bool AllowEditors { get; set; }
    }
}
