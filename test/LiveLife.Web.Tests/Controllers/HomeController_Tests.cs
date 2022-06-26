using System.Threading.Tasks;
using LiveLife.Models.TokenAuth;
using LiveLife.Web.Controllers;
using Shouldly;
using Xunit;

namespace LiveLife.Web.Tests.Controllers
{
    public class HomeController_Tests: LiveLifeWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}