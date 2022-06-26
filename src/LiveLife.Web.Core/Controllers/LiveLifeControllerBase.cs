using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace LiveLife.Controllers
{
    public abstract class LiveLifeControllerBase: AbpController
    {
        protected LiveLifeControllerBase()
        {
            LocalizationSourceName = LiveLifeConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
