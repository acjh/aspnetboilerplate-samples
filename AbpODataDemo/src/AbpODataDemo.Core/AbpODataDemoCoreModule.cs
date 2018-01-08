using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpODataDemo.Localization;

namespace AbpODataDemo
{
    public class AbpODataDemoCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            AbpODataDemoLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpODataDemoCoreModule).GetAssembly());
        }
    }
}