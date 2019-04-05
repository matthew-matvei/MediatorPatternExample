using System.Threading.Tasks;

namespace MediatorPatternExample.Handlers
{
    public interface IRequestHandler<TRequest, TResult>
    {
        Task<TResult> Handle(TRequest request);
    }

    public interface IRequestHandler<TRequest>
    {
        Task Handle(TRequest request);
    }
}
