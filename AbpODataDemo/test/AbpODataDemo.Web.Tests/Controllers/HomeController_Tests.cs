using System.Threading.Tasks;
using AbpODataDemo.Web.Controllers;
using Shouldly;
using Xunit;

namespace AbpODataDemo.Web.Tests.Controllers
{
    public class HomeController_Tests: AbpODataDemoWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
