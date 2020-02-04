using ConsoleApp1.Mappers;
using ConsoleApp1.Messages;

namespace ConsoleApp1.SendMessageRules
{
    public class SingleOfficeSendMessageRule : SendMessageRule
    {
        private readonly Mapper<SingleOfficeMessage, LegacyEvent> mapper;

        public SingleOfficeSendMessageRule(
            Mapper<SingleOfficeMessage, LegacyEvent> mapper)
        {
            this.mapper = mapper;
        }

        public bool ShouldSend(LegacyEvent legacyEvent) =>
            !legacyEvent.IsPerformedByOfficeProcessed &&
            !legacyEvent.IsPerformedOnOfficeProcessed &&
            legacyEvent.PerformedByOfficeId == legacyEvent.PerformedOnOfficeId;

        public Message GetMessage(LegacyEvent legacyEvent) =>
            mapper.Map(legacyEvent);
    }
}