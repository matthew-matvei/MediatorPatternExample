using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatorPatternExample.Models;
using MediatorPatternExample.Models.Queries;
using MediatorPatternExample.Repositories;

namespace MediatorPatternExample.Handlers.Queries
{
    public class ValuesQueryHandler : IRequestHandler<ValuesQuery, IEnumerable<ValueModel>>
    {
        private readonly IValuesReadRepository _valuesReadRepository;
        private readonly IMapper _mapper;

        public ValuesQueryHandler(IValuesReadRepository valuesReadRepository, IMapper mapper)
        {
            _valuesReadRepository = valuesReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ValueModel>> Handle(ValuesQuery request) =>
            _mapper.Map<IEnumerable<ValueModel>>(await _valuesReadRepository.Get());
    }
}
