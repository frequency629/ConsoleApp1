using ConsoleApp1.Mappers;
using ConsoleApp1.Messages;

namespace ConsoleApp1.SendMessageRules
{
    public class EventSendMessageRule : SendMessageRule
    {
        private readonly Mapper<EventMessage, LegacyEvent> mapper;

        public EventSendMessageRule(Mapper<EventMessage, LegacyEvent> mapper)
        {
            this.mapper = mapper;
        }

        public bool ShouldSend(LegacyEvent legacyEvent) =>
            !legacyEvent.IsEventProcessed;

        public Message GetMessage(LegacyEvent legacyEvent) =>
            mapper.Map(legacyEvent);
    }
}