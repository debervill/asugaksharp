namespace asugaksharp.Core.Common;

public class RequestDispatcher
{
    private readonly System.IServiceProvider _serviceProvider;

    public RequestDispatcher(System.IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async System.Threading.Tasks.Task<Result<TResponse>> SendAsync<TResponse>(
        IRequest<TResponse> request,
        System.Threading.CancellationToken ct = default)
    {
        var requestType = request.GetType();
        var responseType = typeof(TResponse);
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, responseType);

        var handler = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions
            .GetServices(_serviceProvider, handlerType);

        if (handler == null)
            return Result<TResponse>.Failure($"Handler not found for {requestType.Name}");

        var method = handlerType.GetMethod("HandleAsync");
        var task = (System.Threading.Tasks.Task<Result<TResponse>>)method!.Invoke(
            handler, new object[] { request, ct })!;

        return await task;
    }
}