using Microsoft.EntityFrameworkCore;
using PostgresqlGemini.Domain.Features.User;

namespace PostgresqlGemini.Infrastructure.Repositories;

internal sealed class UserRepository(ApplicationDbContext dbContext) 
    : Repository<User>(dbContext), IUserRepository
{
    public async Task<User?> ValidateForLoginAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        var result = await DbContext
            .Set<User>()
            .FirstOrDefaultAsync(user =>
                    user.Email == email &&
                    user.Password == GetDbPasswordHash(password),
                cancellationToken);
        result.Password = string.Empty;
        return result;
    }
    private string GetDbPasswordHash(string password)
    {
        return password;
    }
}