using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Abp.Authorization.Users;
using Abp.Extensions;
using LiveLife.Models;

namespace LiveLife.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";
        public ICollection<UserFriend> SentUserFriends { get; set; }
        public ICollection<UserFriend> ReceivedUserFriends { get; set; }
        public ICollection<EventUser> UserEvents { get; set; }
        public User()
        {
            SentUserFriends= new List<UserFriend>();
            ReceivedUserFriends = new List<UserFriend>();
            UserEvents= new List<EventUser>();
        }
        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }
        public UserPage Page { get; set; }
        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }
        public  List<User> GetUserFriends(UserManager userManager)
        {
            var userFriends = new List<User>();
            var addedFriends = SentUserFriends.Where(x => x.InviteStatus == Enums.InviteStatusEnum.Accepted);
            var acceptedFriends = ReceivedUserFriends.Where(x => x.InviteStatus == Enums.InviteStatusEnum.Accepted);
            foreach (var userFriend in addedFriends)
            {
                var friend = userManager.GetUserById(userFriend.ReceiverUserId);
                userFriends.Add(friend);
            }
            foreach (var userFriend in acceptedFriends)
            {
                var friend = userManager.GetUserById(userFriend.SenderUserId);
                userFriends.Add(friend);
            }
            return userFriends;
        }
    }
}
