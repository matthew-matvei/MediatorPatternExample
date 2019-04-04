using System.Threading.Tasks;
using AutoMapper;
using MediatorPatternExample.Models;
using MediatorPatternExample.Models.Commands;
using MediatorPatternExample.UnitsOfWork;

namespace MediatorPatternExample.Handlers.Commands
{
    public class CreateValueCommandHandler : IRequestHandler<CreateValueCommand, ValueModel>
    {
        private readonly IValuesUnitOfWork _valuesUnitOfWork;
        private readonly IMapper _mapper;

        public CreateValueCommandHandler(IValuesUnitOfWork valuesUnitOfWork, IMapper mapper)
        {
            _valuesUnitOfWork = valuesUnitOfWork;
            _mapper = mapper;
        }

        public async Task<ValueModel> Handle(CreateValueCommand request) =>
            _mapper.Map<ValueModel>(await _valuesUnitOfWork.Create(_mapper.Map<ValueModel>(request)));
    }
}
