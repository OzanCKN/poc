using Microsoft.EntityFrameworkCore;
using PostgresqlGemini.Domain.Features.TestData;
using PostgresqlGemini.Domain.Features.User;

namespace PostgresqlGemini.Infrastructure.Repositories;

internal sealed class TestDataRepository : Repository<TestData>, ITestDataRepository
{
    public TestDataRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }

    public void Add(TestData model)
    {
        DbContext.Set<TestData>().Add(model);
    }

    public async Task<TestData> GetLastRecordAsync()
    {
        var testData = await DbContext.Set<TestData>().OrderByDescending(v => v.FirstName).LastAsync();
        return testData;
    }
    //hatalı çözülecek.
    public async Task<List<TestData>> GetTestDataReport()
    {
        var testData = await DbContext.Set<TestData>()
            .AsNoTracking()
            .Where(v => EF.Functions.Like(v.Email.Value, "outlook") ).ToListAsync();

        return testData;
    }

    //update senaryosu optimistic ve pesimistic olarak test edilecek.
    public void Update(TestData model)
    {
        throw new NotImplementedException();
    }

}