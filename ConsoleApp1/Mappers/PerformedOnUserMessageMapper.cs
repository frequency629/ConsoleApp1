using ConsoleApp1.Messages;

namespace ConsoleApp1.Mappers
{
    public class PerformedOnUserMessageMapper : Mapper<PerformedOnUserMessage, LegacyEvent>
    {
        public PerformedOnUserMessage Map(LegacyEvent source) => new PerformedOnUserMessage
        {
            Id = source.Id
        };
    }
}