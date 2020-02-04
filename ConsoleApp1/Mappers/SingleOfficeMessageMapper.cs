using ConsoleApp1.Messages;

namespace ConsoleApp1.Mappers
{
    public class SingleOfficeMessageMapper : Mapper<SingleOfficeMessage, LegacyEvent>
    {
        public SingleOfficeMessage Map(LegacyEvent source) => new SingleOfficeMessage
        {
            Id = source.Id
        };
    }
}