using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application.Test
{
    public class TestAppService : ITestAppService
    {
        private readonly AppDbContext _dbcontext;
        public TestAppService(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> CreateAsync(string name)
        {
            try
            {
                var test = new Domain.Test.Test
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    CreationTime = DateTime.Now
                };
                await _dbcontext.Tests.AddAsync(test);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
