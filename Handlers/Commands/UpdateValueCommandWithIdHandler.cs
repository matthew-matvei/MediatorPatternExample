using System.Threading.Tasks;
using AutoMapper;
using MediatorPatternExample.Models;
using MediatorPatternExample.Models.Commands;
using MediatorPatternExample.UnitsOfWork;

namespace MediatorPatternExample.Handlers.Commands
{
    public class UpdateValueCommandWithIdHandler : IRequestHandler<UpdateValueCommandWithId>
    {
        private readonly IValuesUnitOfWork _valuesUnitOfWork;
        private readonly IMapper _mapper;

        public UpdateValueCommandWithIdHandler(IValuesUnitOfWork valuesUnitOfWork, IMapper mapper)
        {
            _valuesUnitOfWork = valuesUnitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateValueCommandWithId request) =>
            await _valuesUnitOfWork.Update(_mapper.Map<ValueModel>(request));
    }
}
