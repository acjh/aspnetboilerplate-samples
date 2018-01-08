using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpODataDemo.Configuration;
using AbpODataDemo.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace AbpODataDemo.Web.Startup
{
    [DependsOn(
        typeof(AbpODataDemoApplicationModule), 
        typeof(AbpODataDemoEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class AbpODataDemoWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public AbpODataDemoWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(AbpODataDemoConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<AbpODataDemoNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(AbpODataDemoApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpODataDemoWebModule).GetAssembly());
        }
    }
}