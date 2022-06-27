using Abp.Application.Services;
using LiveLife.Events.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveLife.Events
{
    public interface IEventAppService:IApplicationService
    {
        Task<GetEventOutputDto> GetByIdAsync(int id);
        Task<List<GetEventOutputDto>> GetUserEventsAsync(int userId);
        Task<List<GetEventOutputDto>> GetAvaialableEvents();
        Task CreateEventAsync(CreateOrUpdateEventDto input);
        Task UpdateEventAsync(CreateOrUpdateEventDto input);
        Task DeleteEventAsync(int id);

    }
}
