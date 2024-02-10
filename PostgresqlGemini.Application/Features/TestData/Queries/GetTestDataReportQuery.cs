using PostgresqlGemini.Application.Abstraction.MediatrPattern;
using PostgresqlGemini.Application.Features.TestData.Model;
using PostgresqlGemini.Domain.Abstraction;
using PostgresqlGemini.Domain.Features.User;
using Error = PostgresqlGemini.Domain.Abstraction.Error;

namespace PostgresqlGemini.Application.Features.TestData.Queries;

public sealed record GetTestDataReportQuery() : IQuery<List<TestDataModel>>;


internal sealed class GetTestDataReportQueryHandler(ITestDataRepository testDataRepository) : IQueryHandler<GetTestDataReportQuery, List<TestDataModel>>
{
    public async Task<Result<List<TestDataModel>>> Handle(GetTestDataReportQuery request, CancellationToken cancellationToken)
    {
        var result = await testDataRepository.GetTestDataReport();

        try
        {

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Result.Failure<List<TestDataModel>>(new Error("0001", "Bi sıkıntı var."));
        }

        return Result.Success(result.Select(data => 
            new TestDataModel() { Email = data.Email, FirstName = data.FirstName, Id = data.Id, LastName = data.LastName }).ToList());
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