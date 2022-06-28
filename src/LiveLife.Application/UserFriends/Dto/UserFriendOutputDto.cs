using Abp.AutoMapper;
using LiveLife.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveLife.UserFriends.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserFriendOutputDto
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }

        
        public string FullName { get; set; }
    }
}
