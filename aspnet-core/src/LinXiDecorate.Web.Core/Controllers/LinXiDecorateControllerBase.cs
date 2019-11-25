using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace LinXiDecorate.Controllers
{
    public abstract class LinXiDecorateControllerBase: AbpController
    {
        protected LinXiDecorateControllerBase()
        {
            LocalizationSourceName = LinXiDecorateConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
