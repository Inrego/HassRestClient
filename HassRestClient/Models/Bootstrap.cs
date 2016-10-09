using Newtonsoft.Json;

namespace HassRestClient.Models
{
    /// <summary>
    /// Class <see cref="Bootstrap"/>. Contains all the information you need to bootstrap a Home Assistant installation.
    /// </summary>
    public class Bootstrap
    {
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        [JsonProperty("config")]
        public Config Config { get; internal set; }

        /// <summary>
        /// Gets the events.
        /// </summary>
        /// <value>The events.</value>
        [JsonProperty("events")]
        public Event[] Events { get; internal set; }

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <value>The services.</value>
        [JsonProperty("services")]
        public ServiceDomain[] Services { get; internal set; }

        /// <summary>
        /// Gets the states.
        /// </summary>
        /// <value>The states.</value>
        [JsonProperty("states")]
        public EntityState[] States { get; internal set; }
    }
}
