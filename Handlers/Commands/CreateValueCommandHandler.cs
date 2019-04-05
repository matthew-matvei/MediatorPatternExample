using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatorPatternExample.Exceptions;
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

        public class WithArgumentChecking : IRequestHandler<CreateValueCommand, ValueModel>
        {
            private readonly IRequestHandler<CreateValueCommand, ValueModel> _inner;
            private readonly IValidator<CreateValueCommand> _validator;

            public WithArgumentChecking(
                IRequestHandler<CreateValueCommand, ValueModel> inner,
                IValidator<CreateValueCommand> validator)
            {
                _inner = inner;
                _validator = validator;
            }
            public Task<ValueModel> Handle(CreateValueCommand request)
            {
                var validationResult = _validator.Validate(request);
                if (!validationResult.IsValid)
                    throw new InvalidCommandException(validationResult.Errors.Select(_ => _.ErrorMessage).ToArray());

                return _inner.Handle(request);
            }
        }
    }
}
