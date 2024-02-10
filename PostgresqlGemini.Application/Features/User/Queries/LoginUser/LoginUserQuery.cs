using PostgresqlGemini.Application.Abstraction.MediatrPattern;

namespace PostgresqlGemini.Application.Features.User.Queries.LoginUser;

public sealed record LoginUserQuery(
    string email,
    string password) : IQuery<UserLoginResponse>;