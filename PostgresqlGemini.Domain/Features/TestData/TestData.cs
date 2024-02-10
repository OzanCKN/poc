using PostgresqlGemini.Domain.Abstraction;

namespace PostgresqlGemini.Domain.Features.TestData;

public sealed class TestData : Entity
{
    public TestData(Guid id, FirstName firstName, LastName lastName, Email email)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }


    public static TestData Create(FirstName firstName, LastName lastName, Email email)
    {
        var user = new TestData(Guid.NewGuid(), firstName, lastName, email);

        return user;
    }
}