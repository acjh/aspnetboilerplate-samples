using AbpODataDemo.Configuration;
using AbpODataDemo.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AbpODataDemo.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class AbpODataDemoDbContextFactory : IDesignTimeDbContextFactory<AbpODataDemoDbContext>
    {
        public AbpODataDemoDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AbpODataDemoDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(AbpODataDemoConsts.ConnectionStringName)
            );

            return new AbpODataDemoDbContext(builder.Options);
        }
    }
}