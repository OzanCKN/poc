namespace PostgresqlGemini.Application.Features.User.Queries.LoginUser;

public sealed class LoginUserResponse
{
    public string Country { get; init; }

    public string State { get; init; }

    public string ZipCode { get; init; }

    public string City { get; init; }

    public string Street { get; init; }
}