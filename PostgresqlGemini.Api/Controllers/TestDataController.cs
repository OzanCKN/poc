using MediatR;
using Microsoft.AspNetCore.Mvc;
using PostgresqlGemini.Application.Features.TestData.Commands.Create;
using PostgresqlGemini.Application.Features.TestData.Model;
using PostgresqlGemini.Application.Features.TestData.Queries;
using PostgresqlGemini.Domain.Abstraction;

namespace PostgresqlGemini.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestDataController(ISender sender) : ControllerBase
    {
        [Route("create")]
        [HttpPost]
        public async Task<TestDataModel> Create()
        {
            try
            {
                Result<TestDataModel> result = await sender.Send(new CreateTestDataCommand());
                return result.Value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return new();
        }

        [Route("get-data")]
        [HttpGet]
        public async Task<TestDataModel> GetData()
        {
            try
            {
                Result<TestDataModel> result = await sender.Send(new GetTestDataQuery());
                return result.Value;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return new();
        }


        [Route("get-data-report")]
        [HttpGet]
        public async Task<List<TestDataModel>> GetDataReport()
        {
            try
            {
                Result<List<TestDataModel>> result = await sender.Send(new GetTestDataReportQuery());

                return result.Value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return new();
        }
    }

    //[ApiController]
    //[Route("[controller]")]
    //public class ChatController(ISender sender) : ControllerBase
    //{
    //    [HttpPost(Name = "send-message")]
    //    public async Task<bool> SendMessage()
    //    {
    //        return false;
    //    }
    //}
}
