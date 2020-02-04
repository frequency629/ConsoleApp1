using ConsoleApp1.Messages;

namespace ConsoleApp1.Mappers
{
    public class PerformedByOfficeMessageMapper : Mapper<PerformedByOfficeMessage, LegacyEvent>
    {
        public PerformedByOfficeMessage Map(LegacyEvent source) => new PerformedByOfficeMessage
        {
            Id = source.Id
        };
    }
}