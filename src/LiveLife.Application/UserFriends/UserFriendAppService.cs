using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using LiveLife.Authorization.Users;
using LiveLife.Models;
using LiveLife.UserFriends.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveLife.UserFriends
{
    public class UserFriendAppService : LiveLifeAppServiceBase, IUserFriendAppService
    {
        private readonly UserManager _userManager;
        private readonly IRepository<User, long> _userRepository;
        private readonly IMapper _mapper;
        public UserFriendAppService(UserManager userManager,
            IRepository<User, long> userRepository,
            IMapper mapper)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [AbpAuthorize]
        public async Task AcceptUserFriend(int userId)
        {
            try
            {
                var user = await _userRepository.GetAllIncluding(x => x.ReceivedUserFriends).FirstOrDefaultAsync(x => x.Id == AbpSession.UserId);
                var invite = user.ReceivedUserFriends.Where(x => x.SenderUserId == userId && x.InviteStatus != Enums.InviteStatusEnum.Accepted).SingleOrDefault();
                if (invite != null)
                {
                    invite.AcceptationTime = DateTime.Now;
                    invite.InviteStatus = Enums.InviteStatusEnum.Accepted;
                    await _userRepository.UpdateAsync(user);
                }


            }
            catch (Exception ex)
            {

                throw new UserFriendlyException(ex.Message);
            }
        }

        public async Task AddUserFriendAsync(int userId)
        {
            try
            {
                var user = await _userRepository.GetAllIncluding(x => x.SentUserFriends).FirstOrDefaultAsync(x => x.Id == AbpSession.UserId);
                var isFriend =user.GetUserFriends(_userManager).Any(x=>x.Id==userId);
                if (isFriend)
                    throw new Exception("Podany użytkownik jest Twoim znajomym");
                var userFriend = new UserFriend()
                {
                    InviteStatus = Enums.InviteStatusEnum.Sent,
                    IsBlocked = false,
                    ReceiverUserId = userId,
                    SenderUserId = (long)AbpSession.UserId

                };
                user.SentUserFriends.Add(userFriend);
                await _userRepository.UpdateAsync(user);
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException(ex.Message);
            }
        }

        public async Task<List<UserFriendOutputDto>> GetInvitesAsync()
        {
            try
            {
                var user = await _userRepository.GetAll()
                    .Include(x => x.ReceivedUserFriends)
                    .ThenInclude(x => x.SenderUser)
                    .FirstOrDefaultAsync(x => x.Id == AbpSession.UserId);
                var result = new List<UserFriendOutputDto>();
                foreach (var userFriend in user.ReceivedUserFriends)
                {
                    if (userFriend.AcceptationTime is null && userFriend.InviteStatus != Enums.InviteStatusEnum.Accepted)
                    {
                        var friend = _mapper.Map<UserFriendOutputDto>(userFriend.SenderUser);
                        result.Add(friend);
                    }

                }
                return result;
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException(ex.Message);
            }
        }

        public async Task<List<UserFriendOutputDto>> GetUserFriend()
        {
            try
            {
                var user = await _userRepository.GetAll()
                    .Include(x => x.ReceivedUserFriends)
                    .ThenInclude(x => x.SenderUser)
                    .Include(x => x.SentUserFriends)
                    .ThenInclude(x => x.ReceiverUser)
                    .FirstOrDefaultAsync(x => x.Id == AbpSession.UserId);
                var friendList = user.GetUserFriends(_userManager);
                return _mapper.Map<List<UserFriendOutputDto>>(friendList);
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException(ex.Message);
            }

        }

        public async Task<List<UserFriendOutputDto>> SearchFriends(string searchString)
        {
            try
            {
               
                if (string.IsNullOrEmpty(searchString))
                    return new List<UserFriendOutputDto>();
                var searchWords = searchString.Split(' ');
                var searchResult = new List<User>();
                if (searchWords.Length > 1)
                {
                    searchResult = await _userRepository.GetAll()
                        .Where(x => (x.Name.Contains(searchWords[0]) && x.Surname.Contains(searchWords[1]))
                        || (x.Name.Contains(searchWords[1]) && x.Surname.Contains(searchWords[0])))
                        .ToListAsync();

                }
                else
                {
                    searchResult = await _userRepository.GetAll()
                        .Where(x => x.EmailAddress.Contains(searchString)
                        || x.Name.Contains( searchString)
                        || x.Surname.Contains( searchString))
                         .ToListAsync();
                }
                var result= _mapper.Map<List<UserFriendOutputDto>>(searchResult);
                
                var userFriends =  await GetUserFriend();
                foreach(var item in result)
                {
                    if (userFriends.Any(x => x.Id == item.Id) || item.Id==AbpSession.UserId)
                        item.IsFriend = true;
                    else
                        item.IsFriend = false;
                }
                return result;
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException(ex.Message);
            }
            
        }
        //TODO usuwanie oraz wysłane pobieranie
    }
}
