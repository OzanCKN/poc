using PostgresqlGemini.Domain.Features.TestData;
using PostgresqlGemini.Domain.Features.User;
using PostgresqlGemini.Infrastructure;

namespace PostgresqlGemini.TestConsole;

public class BackgroundInserter
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ITestDataRepository _testDataRepository;

    public BackgroundInserter(ApplicationDbContext dbContext, ITestDataRepository testDataRepository)
    {
        _dbContext = dbContext;
        _testDataRepository = testDataRepository;
    }

    public async Task AddRecordsAsync(int recordCount)
    {
        SemaphoreSlim semaphore = new SemaphoreSlim(1);

        var tasks = new List<Task>();

        for (int i = 0; i < recordCount; i++)
        {
            await semaphore.WaitAsync();
            tasks.Add(Task.Run(async () =>
            {
                var data = TestData.Create(
                    new FirstName(GenerateName(20)),
                    new LastName(GenerateName(15)),
                    new Email(GenerateName(30) + "@gmail.com")
                );
                _testDataRepository.Add(data);

                try
                {
                    using (var transaction = await _dbContext.Database.BeginTransactionAsync())
                    {
                        await _dbContext.SaveChangesAsync();
                        await transaction.CommitAsync();
                    }
                }
                finally
                {
                    semaphore.Release(); //sal
                }
            }));
        }

        await Task.WhenAll(tasks); // Tüm asenkron görevlerin tamamlanmasını bekleyin
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