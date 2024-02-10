namespace MessageBus
{
    /// <summary>
    /// This is mesage bus for in-process domain events.
    /// </summary>
    public class InternalMessageBus : IMessageBus
    {
        //Type - type of the event occured.
        //List<Delegate> - all the listeners to that event(subscribers).
        private readonly Dictionary<Type, List<Delegate>> _handlers = new Dictionary<Type, List<Delegate>>();

        // Defualt constructor.
        public InternalMessageBus() { }

        /// <summary>
        /// Notifying all subscribers that an event was raised.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"> Contains all relevant info of the event that was raised. </param>
        public void Publish<T>(T message)
        {
            if (_handlers.ContainsKey(typeof(T)))
            {
                foreach (var handler in _handlers[typeof(T)])
                {
                    handler.DynamicInvoke(message);
                }
            }
        }

        /// <summary>
        /// Subscribes to an event.
        /// Listening and reacting when that event happens.
        /// This way, we update all other modules that are impacted by the change in system.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handler"></param>
        public void Subscribe<T>(Action<T> handler)
        {
            if (!_handlers.ContainsKey(typeof(T)))
            {
                _handlers[typeof(T)] = new List<Delegate>();
            }
            _handlers[typeof(T)].Add(handler);
        } 
    }
}