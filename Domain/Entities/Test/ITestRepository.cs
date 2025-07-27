using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Test
{
    public interface ITestRepository
    {
        Task<bool> CreateAsync(string name);
    }
}
