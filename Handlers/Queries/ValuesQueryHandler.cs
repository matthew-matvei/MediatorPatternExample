using System.Collections.Generic;
using System.Threading.Tasks;
using MediatorPatternExample.Models.DTOs;
using MediatorPatternExample.Models.Queries;

namespace MediatorPatternExample.Handlers.Queries
{
    public class ValuesQueryHandler : IRequestHandler<ValuesQuery, IEnumerable<ValueDTO>>
    {
        public Task<IEnumerable<ValueDTO>> Handle(ValuesQuery request)
        {
            throw new System.NotImplementedException();
        }
    }
}
