using System.Collections.Generic;
using System.Threading.Tasks;
using MediatorPatternExample.Models.Entities;

namespace MediatorPatternExample.Repositories
{
    public interface IValuesReadRepository
    {
        Task<IEnumerable<ValueEntity>> Get();
        Task<ValueEntity> Get(int id);
    }
}
