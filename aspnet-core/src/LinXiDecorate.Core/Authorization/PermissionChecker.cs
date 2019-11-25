using Abp.Authorization;
using LinXiDecorate.Authorization.Roles;
using LinXiDecorate.Authorization.Users;

namespace LinXiDecorate.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
