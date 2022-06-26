using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LiveLife.EntityFrameworkCore;
using LiveLife.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace LiveLife.Web.Tests
{
    [DependsOn(
        typeof(LiveLifeWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class LiveLifeWebTestModule : AbpModule
    {
        public LiveLifeWebTestModule(LiveLifeEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LiveLifeWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(LiveLifeWebMvcModule).Assembly);
        }
    }
}