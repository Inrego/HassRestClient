using Newtonsoft.Json;

namespace HassRestClient.Models
{
    /// <summary>
    /// Class Event.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Gets the name of the event.
        /// </summary>
        /// <value>The name of the event.</value>
        [JsonProperty("event")]
        public string EventName { get; internal set; }

        /// <summary>
        /// Gets the listener count.
        /// </summary>
        /// <value>The listener count.</value>
        [JsonProperty("listener_count")]
        public int ListenerCount { get; internal set; }
    }
}
