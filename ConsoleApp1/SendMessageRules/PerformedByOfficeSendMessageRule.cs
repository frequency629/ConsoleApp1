using ConsoleApp1.Mappers;
using ConsoleApp1.Messages;

namespace ConsoleApp1.SendMessageRules
{
    public class PerformedByOfficeSendMessageRule : SendMessageRule
    {
        private readonly SendMessageRule singleOfficeSendMessageRule;
        private readonly Mapper<PerformedByOfficeMessage, LegacyEvent> mapper;

        public PerformedByOfficeSendMessageRule(
            SendMessageRule singleOfficeSendMessageRule,
            Mapper<PerformedByOfficeMessage, LegacyEvent> mapper)
        {
            this.singleOfficeSendMessageRule = singleOfficeSendMessageRule;
            this.mapper = mapper;
        }

        public bool ShouldSend(LegacyEvent legacyEvent) =>
            !singleOfficeSendMessageRule.ShouldSend(legacyEvent) &&
            !legacyEvent.IsPerformedByOfficeProcessed;

        public Message GetMessage(LegacyEvent legacyEvent) =>
            mapper.Map(legacyEvent);
    }
}