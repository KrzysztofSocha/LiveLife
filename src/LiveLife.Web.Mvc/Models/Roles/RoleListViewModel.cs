using System.Collections.Generic;
using LiveLife.Roles.Dto;

namespace LiveLife.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
