using Flurl.Http;
using PostgresqlGemini.Application.Features.TestData.Model;

namespace PostgresqlGemini.TestConsole.TestDataLogic
{
    internal class TestDataManager
    {
        static string API_URL = "http://localhost:47742";

        public async Task<TestDataModel> CreateTestDataAsync()
        {
            var response = await $"{API_URL}/TestData/create".PostAsync();
            var result = await response.GetJsonAsync<TestDataModel>();
            return result;
        }

        public async Task<TestDataModel?> GetTestDataAsync()
        {
            var response = await $"{API_URL}/TestData/get-data".GetAsync();
            var result = await response.GetJsonAsync<TestDataModel>();

            return result;
        }

        public async Task<List<TestDataModel?>> GetTestDataReportAsync()
        {
            var response = await $"{API_URL}/TestData/get-data-report".GetAsync();
            var result = await response.GetJsonAsync<List<TestDataModel>>();

            return result;
        }
    }
}
