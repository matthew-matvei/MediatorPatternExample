using System.Threading.Tasks;

namespace MediatorPatternExample.Mediator
{
    public interface IMediator
    {
        Task<TResult> Dispatch<TRequest, TResult>(TRequest request);
    }
}
