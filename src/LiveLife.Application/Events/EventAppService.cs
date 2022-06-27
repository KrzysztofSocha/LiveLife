﻿using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using LiveLife.Authorization.Users;
using LiveLife.Events.Dto;
using LiveLife.Models;
using Microsoft.EntityFrameworkCore;
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

                var currentUser = _userManager.GetUserByIdAsync((long)AbpSession.UserId);
                if (currentUser == null)
                    throw new Exception("Aby dodać spotkanie musisz być zalogowany");
               var userEvent= _mapper.Map<Event>(input);
               await _eventRepository.InsertAsync(userEvent);
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException($"Błąd podczas dodwania wydarzenia: {ex.Message}");
            }
        }
        [AbpAuthorize]
        public async Task DeleteEventAsync(int id)
        {
            try
            {
                var eventToDelete =await _eventRepository.FirstOrDefaultAsync(x => x.Id == id);
                if(eventToDelete != null)
                {
                    await _eventRepository.DeleteAsync(id);
                }
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException(ex.Message);
            }
        }
        [AbpAuthorize]
        public async Task<List<GetEventOutputDto>> GetAvaialableEvents()
        {
            try
            {
                var currentUser = await _userManager.GetUserByIdAsync((long)AbpSession.UserId);
                var userFriends = currentUser.GetUserFriends(_userManager);
                var events = await _eventRepository.GetAll()
                    .Include(x=>x.Address)
                    .Where(x => x.IsPublic || userFriends.Select(y=>y.Id).Contains((long) x.CreatorUserId))
                    .OrderByDescending(x=>x.CreationTime)
                    .ToListAsync();
                return _mapper.Map<List<GetEventOutputDto>>(events);
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException(ex.Message);
            }
            
        }

        public async Task<GetEventOutputDto> GetByIdAsync(int id)
        {
            try
            {
                var userEvent =await _eventRepository.GetAllIncluding(x=>x.Address).FirstOrDefaultAsync(x => x.Id == id);
                return _mapper.Map<GetEventOutputDto>(userEvent);
            }
            catch ( Exception ex)
            {

                throw new UserFriendlyException(ex.Message);
            }
        }
        [AbpAuthorize]
        public async Task<List<GetRepotedEventOutput>> GetReportedEvents()
        {
            try
            {
                var reportedEvents = _eventRepository.GetAllIncluding(x => x.Address).Where(x => x.IsReported == true)
                    .OrderByDescending(x=>x.ReportTime);
                return _mapper.Map<List<GetRepotedEventOutput>>(reportedEvents);
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException(ex.Message);
            }
        }

        public async Task<List<GetEventOutputDto>> GetUserEventsAsync(int userId)
        {
            try
            {
                var userEvents = _eventRepository.GetAllIncluding(x => x.Address).Where(x => x.CreatorUserId == AbpSession.UserId);
                return _mapper.Map<List<GetEventOutputDto>>(userEvents);
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException(ex.Message);
            }
        }
        [AbpAuthorize]
        public async Task JoinToEvent(int id)
        {
            try
            {
                var userEvent = await _eventRepository.GetAllIncluding(x=>x.JoinedUsers).FirstOrDefaultAsync(x => x.Id == id);
                userEvent.JoinedUsers.Add(new EventUser()
                {
                    EventId = id,
                    UserId = (long)AbpSession.UserId
                });
                await _eventRepository.UpdateAsync(userEvent);

            }
            catch (Exception ex)
            {

                throw new UserFriendlyException(ex.Message);
            }
        }

        public async Task LeaveEvent(int id)
        {
            try
            {
                var userEvent = await _eventRepository.GetAllIncluding(x => x.JoinedUsers).FirstOrDefaultAsync(x => x.Id == id);
                userEvent.JoinedUsers.Remove(userEvent.JoinedUsers.First(x => x.EventId == id && x.UserId == (long)AbpSession.UserId));
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException(ex.Message);
            }
            
        }

        public async Task ReportEvent(int id)
        {
            try
            {
                var userEvent = await _eventRepository.FirstOrDefaultAsync(x => x.Id == id);
                userEvent.IsReported=true;
                userEvent.ReportTime=DateTime.Now;
                await _eventRepository.UpdateAsync(userEvent);
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException(ex.Message);
            }
        }

        public async Task UpdateEventAsync(CreateOrUpdateEventDto input, int id)
        {
            try
            {
                var userEvent = await _eventRepository.GetAllIncluding(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);
                userEvent = _mapper.Map<CreateOrUpdateEventDto,Event>(input, userEvent);
                await _eventRepository.UpdateAsync(userEvent);
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException(ex.Message);
            }
        }
    }
}