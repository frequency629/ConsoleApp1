using ConsoleApp1.Mappers;
using ConsoleApp1.Messages;

namespace ConsoleApp1.SendMessageRules
{
    public class SingleUserSendMessageRule : SendMessageRule
    {
        private readonly Mapper<SingleUserMessage, LegacyEvent> mapper;

        public SingleUserSendMessageRule(Mapper<SingleUserMessage, LegacyEvent> mapper)
        {
            this.mapper = mapper;
        }
        public bool ShouldSend(LegacyEvent legacyEvent) =>
            !legacyEvent.IsPerformedByUserProcessed &&
            !legacyEvent.IsPerformedOnUserProcessed &&
            legacyEvent.PerformedById == legacyEvent.PerformedOnId;

        public Message GetMessage(LegacyEvent legacyEvent) =>
            mapper.Map(legacyEvent);
    }
}