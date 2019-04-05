using System.Threading.Tasks;

namespace MediatorPatternExample.Mediator
{
    public interface IMediator
    {
        Task<TResult> Dispatch<TRequest, TResult>(TRequest request);
        Task<TResult> Dispatch<TRequest, TResult>() where TRequest : new();
        Task Dispatch<TRequest>(TRequest request);
    }
}
