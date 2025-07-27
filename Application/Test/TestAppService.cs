using Domain.Entities.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application.Test
{
    public class TestAppService : ITestAppService
    {
        private readonly ITestRepository _rep;
        public TestAppService(ITestRepository rep)
        {
            _rep = rep;
        }

        public async Task<bool> CreateAsync(string name)
        {
            try
            {
                await _rep.CreateAsync(name);
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
