using System.Collections.Generic;
using LiveLife.Roles.Dto;

namespace LiveLife.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
