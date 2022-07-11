using LiveLife.Controllers;
using LiveLife.UserFriends;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LiveLife.Web.Controllers
{
    public class UserFriendsController  : LiveLifeControllerBase
    {
        private readonly IUserFriendAppService _userFriendAppService;
        public UserFriendsController(IUserFriendAppService userFriendAppService)
        {
            _userFriendAppService=userFriendAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Search(string searchString)
        {
            var result = await _userFriendAppService.SearchFriends(searchString);
            return View(result);
        }
    }
}
