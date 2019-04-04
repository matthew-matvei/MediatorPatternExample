using System.Threading.Tasks;

namespace MediatorPatternExample.Handlers
{
    public interface IRequestHandler<TRequest, TResult>
    {
        Task<TResult> Handle(TRequest request);
    }
}
