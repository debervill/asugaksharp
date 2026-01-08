namespace asugaksharp.Core.Common;

public interface IRequest<TResponse> { }

public interface IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    System.Threading.Tasks.Task<Result<TResponse>> HandleAsync(
        TRequest request,
        System.Threading.CancellationToken ct = default);
}