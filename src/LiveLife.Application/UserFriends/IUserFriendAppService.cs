using Abp.Application.Services;
using LiveLife.UserFriends.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveLife.UserFriends
{
    public interface IUserFriendAppService:IApplicationService
    {
        Task AddUserFriendAsync(int userId);
        Task<List<UserFriendOutputDto>> GetUserFriend();
        Task AcceptUserFriend(int userId);
        Task<List<UserFriendOutputDto>> GetInvitesAsync();
        Task<List<UserFriendOutputDto>> SearchFriends(string searchString);

    }

}
