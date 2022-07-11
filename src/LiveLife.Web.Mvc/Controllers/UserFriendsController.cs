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
        public async Task<IActionResult> Index()
        {
            var models = await _userFriendAppService.GetUserFriend();
            return View(models);
        }
        public async Task<IActionResult> Search(string searchString)
        {
            var result = await _userFriendAppService.SearchFriends(searchString);
            return View(result);
        }
        public async Task<IActionResult> AddFriend(int id)
        {
             await _userFriendAppService.AddUserFriendAsync(id);
            return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> Invites()
        {
            var models = await _userFriendAppService.GetInvitesAsync();
            return View(models);
        }
        public async Task<IActionResult> AcceptFriend(int id)
        {
            await _userFriendAppService.AcceptUserFriend(id);
            return RedirectToAction("Invites");
        }
    }
}
