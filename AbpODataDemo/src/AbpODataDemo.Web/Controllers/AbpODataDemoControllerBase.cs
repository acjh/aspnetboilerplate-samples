using Abp.AspNetCore.Mvc.Controllers;

namespace AbpODataDemo.Web.Controllers
{
    public abstract class AbpODataDemoControllerBase: AbpController
    {
        protected AbpODataDemoControllerBase()
        {
            LocalizationSourceName = AbpODataDemoConsts.LocalizationSourceName;
        }
    }
}