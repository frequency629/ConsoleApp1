using ConsoleApp1.Messages;

namespace ConsoleApp1.Mappers
{
    public class SingleUserMessageMapper : Mapper<SingleUserMessage, LegacyEvent>
    {
        public SingleUserMessage Map(LegacyEvent source) => new SingleUserMessage
        {
            Id = source.Id
        };
    }
}