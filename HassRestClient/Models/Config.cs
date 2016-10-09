using Newtonsoft.Json;

namespace HassRestClient.Models
{
    /// <summary>
    /// Class Config.
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Gets the components.
        /// </summary>
        /// <value>The components.</value>
        [JsonProperty("components")]
        public string[] Components { get; internal set; }

        /// <summary>
        /// Gets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        [JsonProperty("latitude")]
        public double Latitude { get; internal set; }

        /// <summary>
        /// Gets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        [JsonProperty("longitude")]
        public double Longitude { get; internal set; }

        /// <summary>
        /// Gets the location home.
        /// </summary>
        /// <value>The location home.</value>
        [JsonProperty("location_home")]
        public string LocationHome { get; internal set; }

        /*[JsonProperty("unit_system")]
        public UnitSystem? UnitSystem { get; set; }
        [JsonProperty("temperature_unit")]
        public TemperatureUnit? TemperatureUnit { get; set; }*/

        /// <summary>
        /// Gets the time zone.
        /// </summary>
        /// <value>The time zone.</value>
        [JsonProperty("time_zone")]
        public string TimeZone { get; internal set; }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>The version.</value>
        [JsonProperty("version")]
        public string Version { get; internal set; }
    }

    /// <summary>
    /// Enum unit system
    /// </summary>
    public enum UnitSystem
    {
        /// <summary>
        /// Metric units
        /// </summary>
        Metric
    }
    /// <summary>
    /// Enum temperature unit
    /// </summary>
    public enum TemperatureUnit
    {
        /// <summary>
        /// Celcius
        /// </summary>
        Celcius,
        /// <summary>
        /// Fahrenheit
        /// </summary>
        Fahrenheit
    }
}
