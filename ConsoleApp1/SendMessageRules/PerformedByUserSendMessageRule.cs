using ConsoleApp1.Mappers;
using ConsoleApp1.Messages;

namespace ConsoleApp1.SendMessageRules
{
    public class PerformedByUserSendMessageRule : SendMessageRule
    {
        private readonly SendMessageRule singleUserSendMessageRule;
        private readonly Mapper<PerformedByUserMessage, LegacyEvent> mapper;

        public PerformedByUserSendMessageRule(
            SendMessageRule singleUserSendMessageRule,
            Mapper<PerformedByUserMessage, LegacyEvent> mapper)
        {
            this.singleUserSendMessageRule = singleUserSendMessageRule;
            this.mapper = mapper;
        }

        public bool ShouldSend(LegacyEvent legacyEvent) =>
            !singleUserSendMessageRule.ShouldSend(legacyEvent) &&
            !legacyEvent.IsPerformedByUserProcessed;

        public Message GetMessage(LegacyEvent legacyEvent) =>
            mapper.Map(legacyEvent);
    }
}