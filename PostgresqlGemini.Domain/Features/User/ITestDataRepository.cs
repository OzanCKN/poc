namespace PostgresqlGemini.Domain.Features.User;

public interface ITestDataRepository
{
    void Add(TestData.TestData model);
    Task<TestData.TestData> GetLastRecordAsync();
    Task<List<TestData.TestData>> GetTestDataReport();
    void Update(TestData.TestData model);

}