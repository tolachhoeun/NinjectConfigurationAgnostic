using System;

namespace NinjectConfigurationAgnostic
{
    public class CoffeeMessageHandler : IMessageHandler<CoffeeMessage>
    {
        public void Handle(CoffeeMessage message)
        {
            Console.WriteLine(string.Format("Handle Coffee name {0}; Volume {1}", message.Name, message.Volume));
        }
    }
}
