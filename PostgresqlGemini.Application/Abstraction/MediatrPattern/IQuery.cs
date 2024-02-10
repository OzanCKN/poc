using MediatR;
using PostgresqlGemini.Domain.Abstraction;

namespace PostgresqlGemini.Application.Abstraction.MediatrPattern;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}