using System;
using System.Threading.Tasks;
using Abp.TestBase;
using AbpODataDemo.EntityFrameworkCore;
using AbpODataDemo.Tests.TestDatas;

namespace AbpODataDemo.Tests
{
    public class AbpODataDemoTestBase : AbpIntegratedTestBase<AbpODataDemoTestModule>
    {
        public AbpODataDemoTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<AbpODataDemoDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<AbpODataDemoDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<AbpODataDemoDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<AbpODataDemoDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<AbpODataDemoDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<AbpODataDemoDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<AbpODataDemoDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<AbpODataDemoDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
