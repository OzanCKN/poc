using PostgresqlGemini.Application.Abstraction.MediatrPattern;
using PostgresqlGemini.Domain.Abstraction;
using PostgresqlGemini.Domain.Features.User;

namespace PostgresqlGemini.Application.Features.User.Queries.LoginUser;

internal sealed class LoginUserQueryHandler : IQueryHandler<LoginUserQuery, UserLoginResponse>
{
    private readonly IUserRepository _userRepository;

    public LoginUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<UserLoginResponse>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var result = await _userRepository.ValidateForLoginAsync(request.email, request.password, cancellationToken);

        if (result == null)
        {
            return Result.Failure<UserLoginResponse>(new Error("0001", ""));
        }

        var response = new UserLoginResponse()
        {
            AccessToken = Guid.NewGuid().ToString(),
            RefreshToken = Guid.NewGuid().ToString(),
            MainPageUrl = string.Empty
        };
        return response;
    }
}