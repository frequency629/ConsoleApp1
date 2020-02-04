using ConsoleApp1.Messages;

namespace ConsoleApp1.Mappers
{
    public class EventMessageMapper : Mapper<EventMessage, LegacyEvent>
    {
        public EventMessage Map(LegacyEvent source) => new EventMessage
        {
            Id = source.Id
        };
    }
}