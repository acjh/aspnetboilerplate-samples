using Microsoft.AspNetCore.Mvc;

namespace AbpODataDemo.Web.Controllers
{
    public class HomeController : AbpODataDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}