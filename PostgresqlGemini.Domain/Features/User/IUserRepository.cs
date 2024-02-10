namespace PostgresqlGemini.Domain.Features.User;

public interface IUserRepository
{
    Task<User?> ValidateForLoginAsync(string email, string password, CancellationToken cancellationToken = default);

    void Add(User user);
}