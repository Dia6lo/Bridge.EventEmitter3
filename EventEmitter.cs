//TODO: object => Symbol
using Event = Bridge.Union<string, object>;

namespace Bridge.EventEmitter3
{
    [External]
    public abstract class EventEmitter
    {
        public delegate void ListenerFn(params object[] args);

        public static extern Union<string, bool> Prefixed { get; set; }

        /// <summary>
        /// Return an array listing the events for which the emitter has registered listeners.
        /// </summary>
        public extern Event[] EventNames { [Template("eventNames()")] get; }

        /// <summary>
        /// Return the listeners registered for a given event.
        /// </summary>
        /// <param name="event">The event name.</param>
        /// <param name="exists">Only check if there are listeners.</param>
        public extern Union<ListenerFn[], bool> Listeners(Event @event, bool exists);

        /// <summary>
        /// Return the listeners registered for a given event.
        /// </summary>
        public extern ListenerFn[] Listeners(Event @event);

        /// <summary>
        /// Calls each of the listeners registered for a given event.
        /// </summary>
        public extern bool Emit(Event @event, params object[] args);

        /// <summary>
        /// Add a listener for a given event.
        /// </summary>
        public extern EventEmitter On(Event @event, ListenerFn fn, object context = null);

        /// <summary>
        /// Add a listener for a given event.
        /// </summary>
        public extern EventEmitter AddListener(Event @event, ListenerFn fn, object context = null);

        /// <summary>
        /// Add a one-time listener for a given event.
        /// </summary>
        public extern EventEmitter Once(Event @event, ListenerFn fn, object context = null);

        /// <summary>
        /// Remove the listeners of a given event.
        /// </summary>
        public extern EventEmitter Off(Event @event, ListenerFn fn,
            object context = null, bool? once = null);

        /// <summary>
        /// Remove the listeners of a given event.
        /// </summary>
        public extern EventEmitter RemoveListener(Event @event, ListenerFn fn,
            object context = null, bool? once = null);

        /// <summary>
        /// Remove all listeners, or those of the specified event.
        /// </summary>
        public extern EventEmitter RemoveAllListeners(Event @event);
    }
}