using System.Reflection;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpODataDemo.Web.Startup;

namespace AbpODataDemo.Web.Tests
{
    [DependsOn(
        typeof(AbpODataDemoWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class AbpODataDemoWebTestModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpODataDemoWebTestModule).GetAssembly());
        }
    }
}