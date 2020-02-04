using System;
using ConsoleApp1.Messages;

namespace ConsoleApp1
{
    public class FakeMessagePublisher
    {
        public void Publish(Message message)
        {
            Console.WriteLine($"{message.GetType()} published for event [{message.Id}]");
        }
    }
}