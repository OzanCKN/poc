namespace PostgresqlGemini.Application.Features.User.Queries.LoginUser;

public sealed class UserLoginResponse
{
    public string MainPageUrl { get; set; } = string.Empty;
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}