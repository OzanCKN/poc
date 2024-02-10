using MediatR;
using PostgresqlGemini.Domain.Abstraction;

namespace PostgresqlGemini.Application.Abstraction.MediatrPattern;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>
{
}