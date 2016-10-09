using Newtonsoft.Json;

namespace HassRestClient.Models
{
    /// <summary>
    /// A simple message response from the server.
    /// </summary>
    public class MessageResponse
    {
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>The message.</value>
        [JsonProperty("message")]
        public string Message { get; internal set; }
    }
}
