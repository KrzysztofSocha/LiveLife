using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using LiveLife.Controllers;

namespace LiveLife.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : LiveLifeControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
