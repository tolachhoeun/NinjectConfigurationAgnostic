using System;

namespace NinjectConfigurationAgnostic
{
    public class PersonMessageHandler : IMessageHandler<PersonMessage>
    {
        public void Handle(PersonMessage message)
        {
            Console.WriteLine(string.Format("Handle Person name {0}; Age {1}", message.Name, message.Age));
        }
    }
}
