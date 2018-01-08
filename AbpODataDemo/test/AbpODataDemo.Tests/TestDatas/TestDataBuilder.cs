using AbpODataDemo.EntityFrameworkCore;

namespace AbpODataDemo.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly AbpODataDemoDbContext _context;

        public TestDataBuilder(AbpODataDemoDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}