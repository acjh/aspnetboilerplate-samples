using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace AbpODataDemo
{
    [DependsOn(
        typeof(AbpODataDemoCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AbpODataDemoApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpODataDemoApplicationModule).GetAssembly());
        }
    }
}