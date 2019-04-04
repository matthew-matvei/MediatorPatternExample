using System.Threading.Tasks;
using AutoMapper;
using MediatorPatternExample.Models;
using MediatorPatternExample.Models.Queries;
using MediatorPatternExample.Repositories;

namespace MediatorPatternExample.Handlers.Queries
{
    public class ValueQueryHandler : IRequestHandler<ValueQuery, ValueModel>
    {
        private readonly IValuesReadRepository _valuesReadRepository;
        private readonly IMapper _mapper;

        public ValueQueryHandler(IValuesReadRepository valuesReadRepository, IMapper mapper)
        {
            _valuesReadRepository = valuesReadRepository;
            _mapper = mapper;
        }

        public async Task<ValueModel> Handle(ValueQuery request) =>
            _mapper.Map<ValueModel>(await _valuesReadRepository.Get(request.Id));
    }
}
