using PostgresqlGemini.Application.Abstraction.Clock;

namespace PostgresqlGemini.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
