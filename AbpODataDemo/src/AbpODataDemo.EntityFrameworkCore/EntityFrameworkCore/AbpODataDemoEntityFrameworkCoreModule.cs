using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace AbpODataDemo.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpODataDemoCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class AbpODataDemoEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpODataDemoEntityFrameworkCoreModule).GetAssembly());
        }
    }
}