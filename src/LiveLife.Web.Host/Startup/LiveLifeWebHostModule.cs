using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LiveLife.Configuration;

namespace LiveLife.Web.Host.Startup
{
    [DependsOn(
       typeof(LiveLifeWebCoreModule))]
    public class LiveLifeWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LiveLifeWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LiveLifeWebHostModule).GetAssembly());
        }
    }
}
