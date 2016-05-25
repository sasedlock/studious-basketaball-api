using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace CommandAndQuery.Mediators
{
    public class BasketballMediator : IMediator
    {
        public TResponse Send<TResponse>(IRequest<TResponse> request)
        {
            throw new System.NotImplementedException();
        }

        public Task<TResponse> SendAsync<TResponse>(IAsyncRequest<TResponse> request)
        {
            throw new System.NotImplementedException();
        }

        public void Publish(INotification notification)
        {
            throw new System.NotImplementedException();
        }

        public Task PublishAsync(IAsyncNotification notification)
        {
            throw new System.NotImplementedException();
        }

        public Task PublishAsync(ICancellableAsyncNotification notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<TResponse> SendAsync<TResponse>(ICancellableAsyncRequest<TResponse> request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}