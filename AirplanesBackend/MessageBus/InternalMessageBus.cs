namespace MessageBus
{
    public class InternalMessageBus : IMessageBus
    {
        private readonly Dictionary<Type, List<Delegate>> _handlers = new Dictionary<Type, List<Delegate>>();
        public void Publish<T>(T message)
        {
            List<Delegate>? handlers;
            lock (_handlers)
            {
                if (!_handlers.TryGetValue(typeof(T), value: out handlers))
                {
                    return;
                }
            }

            foreach (var handler in handlers)
            {
                handler.DynamicInvoke(message);
            }
        }

        public void Subscribe<T>(Action<T> handler)
        {
            lock (_handlers)
            {
                if (!_handlers.ContainsKey(typeof(T)))
                {
                    _handlers[typeof(T)] = new List<Delegate>();
                }
                _handlers[typeof(T)].Add(handler);
            }
        }
    }
}
