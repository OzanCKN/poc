namespace PostgresqlGemini.Domain.Features.Chat
{
    public class Chat : BaseEntity
    {
        public string SendedMessage { get; set; }
        public string ReceivedMessage { get; set; }
        public Guid AIID { get; set; }
        public DateTimeOffset SentDate { get; set; }
        public DateTimeOffset? ReceiveDate { get; set; }
    }
}
