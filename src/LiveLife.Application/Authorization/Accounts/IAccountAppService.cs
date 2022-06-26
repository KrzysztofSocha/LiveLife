using System.Threading.Tasks;
using Abp.Application.Services;
using LiveLife.Authorization.Accounts.Dto;

namespace LiveLife.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
