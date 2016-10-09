using Newtonsoft.Json;

namespace HassRestClient.Models
{
    /// <summary>
    /// Contains information about a field/parameter for a service.
    /// </summary>
    public class ServiceFieldInfo
    {
        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("description")]
        public string Description { get; internal set; }

        /// <summary>
        /// Gets the example.
        /// </summary>
        /// <value>The example.</value>
        [JsonProperty("example")]
        public string Example { get; internal set; }
    }
}
