using Abp.AspNetCore.Mvc.Views;

namespace AbpODataDemo.Web.Views
{
    public abstract class AbpODataDemoRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected AbpODataDemoRazorPage()
        {
            LocalizationSourceName = AbpODataDemoConsts.LocalizationSourceName;
        }
    }
}
