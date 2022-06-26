using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LiveLife.Authorization;

namespace LiveLife
{
    [DependsOn(
        typeof(LiveLifeCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class LiveLifeApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<LiveLifeAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(LiveLifeApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
