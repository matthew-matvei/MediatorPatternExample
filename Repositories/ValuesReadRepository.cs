using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatorPatternExample.Models.Entities;

namespace MediatorPatternExample.Repositories
{
    public class ValuesReadRepository : IValuesReadRepository
    {
        public async Task<IEnumerable<ValueEntity>> Get() =>
            await Task.FromResult(new[]
            {
                new ValueEntity { Id = Guid.NewGuid(), Name = "Value 1", Value = 10 },
                new ValueEntity { Id = Guid.NewGuid(), Name = "Value 2", Value = 20 },
                new ValueEntity { Id = Guid.NewGuid(), Name = "Value 3", Value = 30 }
            });
    }
}
