using ConsoleApp1.SendMessageRules;

namespace ConsoleApp1
{
    public class LegacyEventMessagePublisher
    {
        private readonly FakeMessagePublisher messagePublisher;

        public LegacyEventMessagePublisher(FakeMessagePublisher messagePublisher)
        {
            this.messagePublisher = messagePublisher;
        }

        public void SendIf(LegacyEvent legacyEvent, SendMessageRule sendMessageRule)
        {
            if (sendMessageRule.ShouldSend(legacyEvent))
            {
                messagePublisher.Publish(sendMessageRule.GetMessage(legacyEvent));
            }
        }
    }
}