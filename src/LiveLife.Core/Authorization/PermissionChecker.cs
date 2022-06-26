using Abp.Authorization;
using LiveLife.Authorization.Roles;
using LiveLife.Authorization.Users;

namespace LiveLife.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
