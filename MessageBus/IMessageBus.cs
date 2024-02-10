namespace MessageBus
{
    /// <summary>
    /// Used for communication between modules of solution.
    /// </summary>
    public interface IMessageBus
    {
        /// <summary>
        /// Notifying all subscribers that an event was raised.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"> Contains all relevant info of the event that was raised. </param>
        void Publish<T>(T message);

        /// <summary>
        /// Subscribes to an event.
        /// Listening and reacting when that event happens.
        /// This way, we update all other modules that are impacted by the change in system.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handler"></param>
        void Subscribe<T>(Action<T> handler);
    }
}