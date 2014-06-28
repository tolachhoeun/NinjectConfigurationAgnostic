using Ninject;
using Ninject.Extensions.Conventions;
using System;
using System.Collections.Generic;

namespace NinjectConfigurationAgnostic
{
    public class Bootstrap
    {
        public void Run()
        {
            this.ConfigureNinject();
            Console.WriteLine("Configured Ninject");

            var messageList = new List<BaseMessage>();
            messageList.Add(new PersonMessage() { Name = "Jame", Age = 20 });
            messageList.Add(new CoffeeMessage() { Name = "Mocha", Volume = 1 });
            messageList.Add(new PersonMessage() { Name = "Ken", Age = 15 });
            messageList.Add(new CoffeeMessage() { Name = "Cappuccino", Volume = 1 });
            messageList.Add(new PersonMessage() { Name = "Tim", Age = 35 });
            messageList.Add(new CoffeeMessage() { Name = "Late", Volume = 1 });

            foreach (var message in messageList)
            {
                //if (message is PersonMessage)
                //{
                //    var handler = this.kernel.Get<IMessageHandler<PersonMessage>>();
                //    handler.Handle(message as PersonMessage);
                //}
                //else if (message is CoffeeMessage)
                //{
                //    var handler = this.kernel.Get<IMessageHandler<CoffeeMessage>>();
                //    handler.Handle(message as CoffeeMessage);
                //}

                this.ProcessMessage(message);
            }
        }

        private IKernel kernel;

        private void ConfigureNinject()
        {
            this.kernel = new StandardKernel();
            //this.kernel.Bind<IMessageHandler<PersonMessage>>().To<PersonMessageHandler>();
            //this.kernel.Bind<IMessageHandler<CoffeeMessage>>().To<CoffeeMessageHandler>();
            this.kernel.Bind(x => x.FromThisAssembly().SelectAllClasses().InheritedFrom(typeof(IMessageHandler<>)).BindAllInterfaces());
        }

        private void ProcessMessage<T>(T message) where T : class
        {
            // Mam Baa Jam Baa code to construct the right message handler type
            Type handlerType = typeof(IMessageHandler<>);
            Type[] typeArgs = { message.GetType() };
            Type constructed = handlerType.MakeGenericType(typeArgs);
            // Here we are the Chosen One message handler
            var handler = this.kernel.Get(constructed);

            // Invoke handle message
            var methodInfo = constructed.GetMethod("Handle");
            methodInfo.Invoke(handler, new[] { message });
        }
    }
}
