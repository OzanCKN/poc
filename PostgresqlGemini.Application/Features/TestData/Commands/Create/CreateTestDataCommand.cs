using PostgresqlGemini.Application.Abstraction.MediatrPattern;
using PostgresqlGemini.Application.Features.TestData.Model;
using PostgresqlGemini.Domain.Abstraction;
using PostgresqlGemini.Domain.Features.TestData;
using PostgresqlGemini.Domain.Features.User;

namespace PostgresqlGemini.Application.Features.TestData.Commands.Create;

public sealed record CreateTestDataCommand() : ICommand<TestDataModel>;


internal sealed class CreateTestDataCommandHandler
    (ITestDataRepository testDataRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateTestDataCommand, TestDataModel>
{
    public async Task<Result<TestDataModel>> Handle(CreateTestDataCommand request, CancellationToken cancellationToken)
    {
        //bla bla
        var data = Domain.Features.TestData.TestData.Create(
            new FirstName(GenerateName(10)),
            new LastName(GenerateName(10)),
            new Email($"{GenerateName(10)}@outlook.com")
        );
        testDataRepository.Add(data);

        try
        {
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Result.Failure<TestDataModel>(new("#0001", "bi sıkıntı var"));
        }

        return Result.Success(new TestDataModel() { Email = data.Email, FirstName = data.FirstName, Id = data.Id, LastName = data.LastName });
    }

    private string GenerateName(int len)
    {
        Random r = new Random();
        string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
        string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
        string Name = "";
        Name += consonants[r.Next(consonants.Length)].ToUpper();
        Name += vowels[r.Next(vowels.Length)];
        int b = 2;
        while (b < len)
        {
            Name += consonants[r.Next(consonants.Length)];
            b++;
            Name += vowels[r.Next(vowels.Length)];
            b++;
        }

        return Name;
    }
}