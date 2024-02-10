using System.Diagnostics;
using Newtonsoft.Json;
using PostgresqlGemini.Application.Features.TestData.Model;
using PostgresqlGemini.TestConsole.TestDataLogic;

namespace PostgresqlGemini.TestConsole.TestAll
{
    internal class TestManager
    {
        public async Task StartInsertAsync(int insertCount)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var testDataManager = new TestDataManager();
            for (int i = 0; i <= insertCount; i++)
            {
                var result = await testDataManager.CreateTestDataAsync();
                Console.WriteLine("---------------");
                Console.WriteLine(JsonConvert.SerializeObject(result));
                Console.WriteLine("---------------");
            }

            stopwatch.Stop();
            Console.WriteLine("Elapsed Time(StartInsertAsync):" + stopwatch.ToString());

        }

        public async Task<TestDataModel> GetTestDataAsync()
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var testDataManager = new TestDataManager();

            var result = await testDataManager.GetTestDataAsync();
            Console.WriteLine("---------------");
            Console.WriteLine(JsonConvert.SerializeObject(result));
            Console.WriteLine("---------------");

            stopwatch.Stop();
            Console.WriteLine("Elapsed Time(GetTestDataAsync):" + stopwatch.ToString());

            return result;
        }

        //tamamlanmadı
        public async Task<List<TestDataModel>> GetTestDataReportAsync()
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var testDataManager = new TestDataManager();

            var result = await testDataManager.GetTestDataReportAsync();

            Console.WriteLine("---------------");
            Console.WriteLine(JsonConvert.SerializeObject(result));
            Console.WriteLine("---------------");

            stopwatch.Stop();
            Console.WriteLine("Elapsed Time(GetTestDataAsync):" + stopwatch.ToString());

            return result;
        }
    }
}
