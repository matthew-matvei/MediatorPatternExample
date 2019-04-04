using System.Threading.Tasks;
using MediatorPatternExample.Models;
using MediatorPatternExample.Models.Entities;

namespace MediatorPatternExample.UnitsOfWork
{
    public interface IValuesUnitOfWork
    {
        Task<ValueEntity> Create(ValueModel value);
    }
}
