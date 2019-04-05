using System.Threading.Tasks;
using MediatorPatternExample.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorPatternExample.Mediator
{
    public class Mediator : IMediator
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public Mediator(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public Task<TResult> Dispatch<TRequest, TResult>(TRequest request) =>
            DispatchPrivate<TRequest, TResult>(request);

        public Task<TResult> Dispatch<TRequest, TResult>() where TRequest : new() =>
            DispatchPrivate<TRequest, TResult>(new TRequest());

        public Task Dispatch<TRequest>(TRequest request) =>
            DispatchPrivate<TRequest>(request);

        private async Task<TResult> DispatchPrivate<TRequest, TResult>(TRequest request)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var handler = scope.ServiceProvider.GetRequiredService<IRequestHandler<TRequest, TResult>>();
                return await handler.Handle(request);
            }
        }

        private async Task DispatchPrivate<TRequest>(TRequest request)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var handler = scope.ServiceProvider.GetRequiredService<IRequestHandler<TRequest>>();
                await handler.Handle(request);
            }
        }
    }
}
