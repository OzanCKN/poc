using PostgresqlGemini.Domain.Features.TestData;

namespace PostgresqlGemini.Application.Features.TestData.Model
{
    public class TestDataModel
    {
        public Guid Id { get; set; }
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public Email Email { get; set; }

    }
}
