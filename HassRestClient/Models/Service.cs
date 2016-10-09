using System.Collections.Generic;
using Newtonsoft.Json;

namespace HassRestClient.Models
{
    /// <summary>
    /// Class Service.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Gets the domain.
        /// </summary>
        /// <value>The domain.</value>
        public string Domain { get; internal set; }
        /// <summary>
        /// Gets the name of the service.
        /// </summary>
        /// <value>The name of the service.</value>
        public string ServiceName { get; internal set; }
        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("description")]
        public string Description { get; internal set; }
        /// <summary>
        /// Gets the fields.
        /// </summary>
        /// <value>The fields.</value>
        [JsonProperty("fields")]
        public Dictionary<string, ServiceFieldInfo> Fields { get; internal set; }
    }
}
