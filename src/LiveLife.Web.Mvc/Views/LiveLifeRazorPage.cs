using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace LiveLife.Web.Views
{
    public abstract class LiveLifeRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected LiveLifeRazorPage()
        {
            LocalizationSourceName = LiveLifeConsts.LocalizationSourceName;
        }
    }
}
