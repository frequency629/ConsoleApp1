using System;
using System.Collections.Generic;
using ConsoleApp1.Mappers;
using ConsoleApp1.SendMessageRules;

namespace ConsoleApp1
{
    class Program
    {
        private static SendMessageRule singleUserSendMessageRule =
            new SingleUserSendMessageRule(new SingleUserMessageMapper());
        private static SendMessageRule singleOfficeSendMessageRule =
            new SingleOfficeSendMessageRule(new SingleOfficeMessageMapper());

        private static IList<SendMessageRule> sendMessageRules = new List<SendMessageRule>
        {
            new EventSendMessageRule(new EventMessageMapper()),
            singleUserSendMessageRule,
            new PerformedOnUserSendMessageRule(singleUserSendMessageRule, new PerformedOnUserMessageMapper()),
            new PerformedByUserSendMessageRule(singleUserSendMessageRule, new PerformedByUserMessageMapper()),
            singleOfficeSendMessageRule,
            new PerformedOnOfficeSendMessageRule(singleOfficeSendMessageRule, new PerformedOnOfficeMessageMapper()),
            new PerformedByOfficeSendMessageRule(singleOfficeSendMessageRule, new PerformedByOfficeMessageMapper())
        };

        static void Main(string[] args)
        {
            var publisher = new LegacyEventMessagePublisher(new FakeMessagePublisher());

            var legacyEvents = new List<LegacyEvent>
            {
                new LegacyEvent
                {
                    Id = Guid.NewGuid(),
                    IsPerformedByOfficeProcessed = true
                }
            };
            foreach (var legacyEvent in legacyEvents)
            {
                foreach (var sendMessageRule in sendMessageRules)
                {
                    publisher.SendIf(legacyEvent, sendMessageRule);
                }
            }

            Console.ReadKey(true);
        }
    }
}
