using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AbpODataDemo.EntityFrameworkCore
{
    public class AbpODataDemoDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public AbpODataDemoDbContext(DbContextOptions<AbpODataDemoDbContext> options) 
            : base(options)
        {

        }
    }
}
