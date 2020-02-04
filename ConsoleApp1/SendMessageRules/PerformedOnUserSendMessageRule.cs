using ConsoleApp1.Mappers;
using ConsoleApp1.Messages;

namespace ConsoleApp1.SendMessageRules
{
    public class PerformedOnUserSendMessageRule : SendMessageRule
    {
        private readonly SendMessageRule singleUserSendMessageRule;
        private readonly Mapper<PerformedOnUserMessage, LegacyEvent> mapper;

        public PerformedOnUserSendMessageRule(
            SendMessageRule singleUserSendMessageRule,
            Mapper<PerformedOnUserMessage, LegacyEvent> mapper)
        {
            this.singleUserSendMessageRule = singleUserSendMessageRule;
            this.mapper = mapper;
        }

        public bool ShouldSend(LegacyEvent legacyEvent) =>
            !singleUserSendMessageRule.ShouldSend(legacyEvent) &&
            !legacyEvent.IsPerformedOnUserProcessed;

        public Message GetMessage(LegacyEvent legacyEvent) =>
            mapper.Map(legacyEvent);
    }
}