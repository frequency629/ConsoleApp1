using ConsoleApp1.Messages;

namespace ConsoleApp1.Mappers
{
    public class PerformedOnOfficeMessageMapper : Mapper<PerformedOnOfficeMessage, LegacyEvent>
    {
        public PerformedOnOfficeMessage Map(LegacyEvent source) => new PerformedOnOfficeMessage
        {
            Id = source.Id
        };
    }
}