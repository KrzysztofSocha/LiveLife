using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using LiveLife.Authorization.Users;
using LiveLife.MultiTenancy;
using AutoMapper;

namespace LiveLife
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class LiveLifeAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }
        private readonly IMapper _mapper;

        protected LiveLifeAppServiceBase()
        {
           
            LocalizationSourceName = LiveLifeConsts.LocalizationSourceName;
        }
        public LiveLifeAppServiceBase(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
