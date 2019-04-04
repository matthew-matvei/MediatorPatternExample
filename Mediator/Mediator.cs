using System.Threading.Tasks;

namespace MediatorPatternExample.Mediator
{
    public class Mediator : IMediator
    {
        public Task<TResult> Dispatch<TRequest, TResult>(TRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<TResult> Dispatch<TRequest, TResult>() where TRequest : new()
        {
            throw new System.NotImplementedException();
        }

        public Task<TResult> Dispatch<TResult>(object request)
        {
            throw new System.NotImplementedException();
        }
    }
}
