using System.Threading.Tasks;

namespace MediatorPatternExample.Mediator
{
    public interface IRequestHandler<TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}
