
namespace NinjectConfigurationAgnostic
{
    interface IMessageHandler<T> where T : BaseMessage
    {
        void Handle(T message);
    }
}
