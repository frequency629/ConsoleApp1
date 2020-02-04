using ConsoleApp1.Messages;

namespace ConsoleApp1.SendMessageRules
{
    public interface SendMessageRule
    {
        bool ShouldSend(LegacyEvent legacyEvent);

        Message GetMessage(LegacyEvent legacyEvent);
    }
}