using Microsoft.EntityFrameworkCore;

namespace AbpODataDemo.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<AbpODataDemoDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for AbpODataDemoDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
