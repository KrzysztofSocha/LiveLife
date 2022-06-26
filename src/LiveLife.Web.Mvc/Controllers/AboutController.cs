using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using LiveLife.Controllers;

namespace LiveLife.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : LiveLifeControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
