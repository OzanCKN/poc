using MediatR;
using PostgresqlGemini.Domain.Abstraction;

namespace PostgresqlGemini.Application.Abstraction.MediatrPattern;

public interface ICommand : IRequest<Result>, IBaseCommand
{
}

public interface ICommand<TReponse> : IRequest<Result<TReponse>>, IBaseCommand
{
}

public interface IBaseCommand
{
}