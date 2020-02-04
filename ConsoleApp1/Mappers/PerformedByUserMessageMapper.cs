using ConsoleApp1.Messages;

namespace ConsoleApp1.Mappers
{
    public class PerformedByUserMessageMapper : Mapper<PerformedByUserMessage, LegacyEvent>
    {
        public PerformedByUserMessage Map(LegacyEvent source) => new PerformedByUserMessage
        {
            Id = source.Id
        };
    }
}