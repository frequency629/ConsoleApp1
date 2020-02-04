using ConsoleApp1.Mappers;
using ConsoleApp1.Messages;

namespace ConsoleApp1.SendMessageRules
{
    public class PerformedOnOfficeSendMessageRule : SendMessageRule
    {
        private readonly SendMessageRule singleOfficeSendMessageRule;
        private readonly Mapper<PerformedOnOfficeMessage, LegacyEvent> mapper;

        public PerformedOnOfficeSendMessageRule(
            SendMessageRule singleOfficeSendMessageRule,
            Mapper<PerformedOnOfficeMessage, LegacyEvent> mapper)
        {
            this.singleOfficeSendMessageRule = singleOfficeSendMessageRule;
            this.mapper = mapper;
        }

        public bool ShouldSend(LegacyEvent legacyEvent) =>
            !singleOfficeSendMessageRule.ShouldSend(legacyEvent) &&
            !legacyEvent.IsPerformedOnOfficeProcessed;

        public Message GetMessage(LegacyEvent legacyEvent) =>
            mapper.Map(legacyEvent);
    }
}