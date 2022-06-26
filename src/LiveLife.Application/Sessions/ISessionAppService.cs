using System.Threading.Tasks;
using Abp.Application.Services;
using LiveLife.Sessions.Dto;

namespace LiveLife.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
