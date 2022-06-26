using System.Collections.Generic;
using LiveLife.Roles.Dto;

namespace LiveLife.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}