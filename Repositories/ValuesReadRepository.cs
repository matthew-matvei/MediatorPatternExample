using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatorPatternExample.Exceptions;
using MediatorPatternExample.Models.Entities;

namespace MediatorPatternExample.Repositories
{
    public class ValuesReadRepository : IValuesReadRepository
    {
        public async Task<IEnumerable<ValueEntity>> Get() =>
            await Task.FromResult(FakeData);

        public async Task<ValueEntity> Get(int id) =>
            await Task.FromResult(FakeData.FirstOrDefault(value => value.Id == id) ??
                throw new ValueNotFoundException(id));

        private static IEnumerable<ValueEntity> FakeData => new[]
            {
                new ValueEntity { Id = 1, Name = "Value 1", Value = 10 },
                new ValueEntity { Id = 2, Name = "Value 2", Value = 20 },
                new ValueEntity { Id = 3, Name = "Value 3", Value = 30 }
            };
    }
}
