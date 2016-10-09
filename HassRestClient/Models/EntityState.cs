using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HassRestClient.Models
{
    /// <summary>
    /// The state of an entity.
    /// </summary>
    public class EntityState
    {
        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        /// <value>The attributes.</value>
        [JsonProperty("attributes")]
        public Dictionary<string, object> Attributes { get; set; }

        /// <summary>
        /// Gets the entity identifier.
        /// </summary>
        /// <value>The entity identifier.</value>
        [JsonProperty("entity_id")]
        public string EntityId { get; internal set; }

        /// <summary>
        /// Gets the last changed time.
        /// </summary>
        /// <value>The last changed.</value>
        [JsonProperty("last_changed")]
        public DateTime LastChanged { get; internal set; }
        /// <summary>
        /// Gets the last updated time.
        /// </summary>
        /// <value>The last updated.</value>
        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; internal set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [JsonProperty("state")]
        public string State { get; set; }
    }
}
