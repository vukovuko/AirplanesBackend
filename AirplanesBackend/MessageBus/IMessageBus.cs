namespace MessageBus
{
    public interface IMessageBus
    {
        void Publish<T>(T message);
        void Subscribe<T>(Action<T> handler);
    }
}