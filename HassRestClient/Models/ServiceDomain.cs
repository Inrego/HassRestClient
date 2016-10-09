using System.Collections.Generic;
using Newtonsoft.Json;

namespace HassRestClient.Models
{
    /// <summary>
    /// Class ServiceDomain.
    /// </summary>
    public class ServiceDomain
    {
        /// <summary>
        /// Gets the domain.
        /// </summary>
        /// <value>The domain.</value>
        [JsonProperty("domain")]
        public string Domain { get; internal set; }

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <value>The services.</value>
        [JsonProperty("services")]
        public Dictionary<string, Service> Services { get; internal set; }
    }
}
