using Newtonsoft.Json;

namespace HassRestClient.Models
{
    /// <summary>
    /// Class DiscoveryInfo.
    /// </summary>
    public class DiscoveryInfo
    {
        /// <summary>
        /// Gets the base URL.
        /// </summary>
        /// <value>The base URL.</value>
        [JsonProperty("baseUrl")]
        public string BaseUrl { get; internal set; }

        /// <summary>
        /// Gets the location name.
        /// </summary>
        /// <value>The name of the location.</value>
        [JsonProperty("location_name")]
        public string LocationName { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether api password is required..
        /// </summary>
        /// <value><c>true</c> if api password is required; otherwise, <c>false</c>.</value>
        [JsonProperty("requires_api_password")]
        public bool RequiresApiPassword { get; internal set; }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>The version.</value>
        [JsonProperty("version")]
        public string Version { get; internal set; }
    }
}
