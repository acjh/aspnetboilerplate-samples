using System;
using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Dependency;
using AbpODataDemo.EntityFrameworkCore;
using AbpODataDemo.Web.Controllers;
using Castle.MicroKernel.Registration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AbpODataDemo.Web.Tests
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkInMemoryDatabase();

            services.AddMvc();

            //Configure Abp and Dependency Injection
            return services.AddAbp<AbpODataDemoWebTestModule>(options =>
            {
                options.SetupTest();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            UseInMemoryDb(app.ApplicationServices);

            app.UseAbp(); //Initializes ABP framework.

            app.UseExceptionHandler("/Error");

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }

        private void UseInMemoryDb(IServiceProvider serviceProvider)
        {
            var builder = new DbContextOptionsBuilder<AbpODataDemoDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).UseInternalServiceProvider(serviceProvider);
            var options = builder.Options;

            var iocManager = serviceProvider.GetRequiredService<IIocManager>();

            iocManager.IocContainer
                .Register(
                    Component.For<DbContextOptions<AbpODataDemoDbContext>>()
                    .Instance(options)
                    .LifestyleSingleton()
                );
        }
    }
}
