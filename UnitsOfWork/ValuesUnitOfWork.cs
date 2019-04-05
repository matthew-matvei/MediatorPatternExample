using System.Threading.Tasks;
using MediatorPatternExample.Models;
using MediatorPatternExample.Models.Entities;

namespace MediatorPatternExample.UnitsOfWork
{
    public class ValuesUnitOfWork : IValuesUnitOfWork
    {
        public Task<ValueEntity> Create(ValueModel value) =>
            Task.FromResult(new ValueEntity
            {
                Id = 10,
                Name = value.Name,
                Value = value.Value
            });
    }
}
