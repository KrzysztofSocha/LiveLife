using Abp.AspNetCore.Mvc.ViewComponents;

namespace LiveLife.Web.Views
{
    public abstract class LiveLifeViewComponent : AbpViewComponent
    {
        protected LiveLifeViewComponent()
        {
            LocalizationSourceName = LiveLifeConsts.LocalizationSourceName;
        }
    }
}
