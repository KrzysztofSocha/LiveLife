using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using LiveLife.Authorization.Users;
using LiveLife.Events.Dto;
using LiveLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveLife.Events
{
    public class EventAppService : LiveLifeAppServiceBase, IEventAppService
    {
        private readonly IRepository<Event> _eventRepository;
        private readonly IMapper _mapper;
        private readonly UserManager _userManager;
        public EventAppService(IRepository<Event> eventRepository, 
            IMapper mapper,
            UserManager userManager)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _userManager = userManager;
        }
        [AbpAuthorize]
        public async Task CreateEventAsync(CreateOrUpdateEventDto input)
        {
            try
            {
               
               var user=  _userManager.FindByIdAsync(AbpSession.UserId.ToString());
                if (user.Result == null)
                    throw new Exception("Aby dodać spotkanie musisz być zalogowany");
               var userEvent= _mapper.Map<Event>(input);
               await _eventRepository.InsertAsync(userEvent);
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException($"Błąd podczas dodwania wydarzenia: {ex.Message}");
            }
        }

        public Task DeleteEventAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetEventOutputDto>> GetAvaialableEvents()
        {
            throw new NotImplementedException();
        }

        public Task<GetEventOutputDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetEventOutputDto>> GetUserEventsAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEventAsync(CreateOrUpdateEventDto input)
        {
            throw new NotImplementedException();
        }
    }
}