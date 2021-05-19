using Microsoft.AspNetCore.Authorization;

namespace Users.Infrastructure
{
    public class BlockUsersRequirement : IAuthorizationRequirement
    {
        public BlockUsersRequirement(params string[] users) => BlockedUsers = users;

        public string[] BlockedUsers { get; set; }
    }
}
