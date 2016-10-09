using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HassRestClient.Models;
using Newtonsoft.Json;

namespace HassRestClient
{
    /// <summary>
    /// A client to do all api calls to a Home Assistant installation.
    /// </summary>
    public class ApiClient : IDisposable
    {
        private readonly string _hassUrl;
        private readonly HttpClient _client;
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient"/> class.
        /// </summary>
        /// <param name="hassUrl">The URL to the HA installation.</param>
        /// <param name="password">Password (if any) for Home Assistant. Specified as api_password under http section in HA config file.</param>
        public ApiClient(string hassUrl, string password)
        {
            _hassUrl = hassUrl.ToLower();
            if (_hassUrl.EndsWith("/"))
                _hassUrl += "/";
            if (!_hassUrl.EndsWith("/api/"))
                _hassUrl += "api/";
            _client = new HttpClient();
            if (!string.IsNullOrEmpty(password))
                _client.DefaultRequestHeaders.Add("x-ha-access", password);
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient"/> class.
        /// </summary>
        /// <param name="hassUrl">The URL to the HA installation.</param>
        public ApiClient(string hassUrl) : this(hassUrl, null)
        {
        }

        /// <summary>
        /// Get all information required to bootstrap the HA installation. (<see cref="ApiClient"/>, <see cref="Event"/>, <see cref="ServiceDomain"/> and <see cref="EntityState"/>).<para />
        /// See more: <a href="https://home-assistant.io/developers/rest_api/#get-apibootstrap">https://home-assistant.io/developers/rest_api/#get-apibootstrap</a>
        /// </summary>
        /// <returns><see cref="Bootstrap"/>.</returns>
        public async Task<Bootstrap> GetBootstrapAsync()
        {
            var url = _hassUrl + "bootstrap";
            var resp = await _client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<Bootstrap>(resp, new ServiceConverter());
        }
        /// <summary>
        /// Get configuration.<para />
        /// See more: <a href="https://home-assistant.io/developers/rest_api/#get-apiconfig">https://home-assistant.io/developers/rest_api/#get-apiconfig</a>
        /// </summary>
        /// <returns><see cref="Config"/>.</returns>
        public async Task<Config> GetConfigAsync()
        {
            var url = _hassUrl + "config";
            var resp = await _client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<Config>(resp);
        }
        /// <summary>
        /// Get discovery information.<para />
        /// See more: <a href="https://home-assistant.io/developers/rest_api/#get-apidiscovery_info">https://home-assistant.io/developers/rest_api/#get-apidiscovery_info</a>
        /// </summary>
        /// <returns><see cref="DiscoveryInfo"/>.</returns>
        public async Task<DiscoveryInfo> GetDiscoveryInfoAsync()
        {
            var url = _hassUrl + "discovery_info";
            var resp = await _client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<DiscoveryInfo>(resp);
        }
        /// <summary>
        /// Get events.<para />
        /// See more: <a href="https://home-assistant.io/developers/rest_api/#get-apievents">https://home-assistant.io/developers/rest_api/#get-apievents</a>
        /// </summary>
        /// <returns><see cref="Event"/>[].</returns>
        public async Task<Event[]> GetEventsAsync()
        {
            var url = _hassUrl + "events";
            var resp = await _client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<Event[]>(resp);
        }
        /// <summary>
        /// Get services. These are the different commands you can call on each entity.<para />
        /// See more: <a href="https://home-assistant.io/developers/rest_api/#get-apiservices">https://home-assistant.io/developers/rest_api/#get-apiservices</a>
        /// </summary>
        /// <returns><see cref="ServiceDomain"/>[].</returns>
        public async Task<ServiceDomain[]> GetServicesAsync()
        {
            var url = _hassUrl + "services";
            var resp = await _client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<ServiceDomain[]>(resp, new ServiceConverter());
        }
        /// <summary>
        /// Get the states of all entities.<para />
        /// See more: <a href="https://home-assistant.io/developers/rest_api/#get-apistates">https://home-assistant.io/developers/rest_api/#get-apistates</a>
        /// </summary>
        /// <returns><see cref="EntityState"/>[].</returns>
        public async Task<EntityState[]> GetStatesAsync()
        {
            var url = _hassUrl + "states";
            var resp = await _client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<EntityState[]>(resp);
        }
        /// <summary>
        /// Get state for a single entity.<para />
        /// See more: <a href="https://home-assistant.io/developers/rest_api/#get-apistatesltentity_id">https://home-assistant.io/developers/rest_api/#get-apistatesltentity_id</a>
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <returns><see cref="EntityState"/>.</returns>
        public async Task<EntityState> GetStateAsync(string entityId)
        {
            var url = _hassUrl + "states/" + entityId;
            var resp = await _client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<EntityState>(resp);
        }
        /// <summary>
        /// Gets the picture from a camera entity.<para />
        /// See more: <a href="https://home-assistant.io/developers/rest_api/#get-apicamera_proxycameraltentity_id">https://home-assistant.io/developers/rest_api/#get-apicamera_proxycameraltentity_id</a>
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <returns>Picture as <see cref="byte"/>[].</returns>
        public Task<byte[]> GetCameraPictureAsync(string entityId)
        {
            var url = _hassUrl + "camera_proxy/" + entityId;
            return _client.GetByteArrayAsync(url);
        }
        /// <summary>
        /// Update the state of an entity.<para />
        /// See more: <a href="https://home-assistant.io/developers/rest_api/#post-apistatesltentity_id">https://home-assistant.io/developers/rest_api/#post-apistatesltentity_id</a>
        /// </summary>
        /// <param name="state">The <see cref="EntityState"/> that you want to update.</param>
        /// <returns>An <see cref="EntityState"/> object with the updated state(s).</returns>
        public async Task<EntityState> UpdateStateAsync(EntityState state)
        {
            var url = _hassUrl + "states/" + state.EntityId;
            var json = JsonConvert.SerializeObject(new
            {
                state = state.State,
                attributes = state.Attributes
            });
            var resp = await _client.PostAsync(url, new StringContent(json));
            var respStr = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<EntityState>(respStr);
        }
        /// <summary>
        /// Fire an event on the HA installation.<para />
        /// See more: <a href="https://home-assistant.io/developers/rest_api/#post-apieventsltevent_type">https://home-assistant.io/developers/rest_api/#post-apieventsltevent_type</a>
        /// </summary>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="eventData">The event data.</param>
        /// <returns>A simple <see cref="MessageResponse"/> with a message about success.</returns>
        public async Task<MessageResponse> FireEventAsync(string eventType, object eventData = null)
        {
            var url = _hassUrl + "events/" + eventType;
            var json = JsonConvert.SerializeObject(eventData);
            var resp = await _client.PostAsync(url, new StringContent(json));
            var respStr = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MessageResponse>(respStr);
        }
        /// <summary>
        /// Call a service.<para />
        /// Note: The result will include any changed states that changed while the service was being executed, even if their change was the result of something else happening in the system.<para />
        /// See more: <a href="https://home-assistant.io/developers/rest_api/#post-apiservicesltdomainltservice">https://home-assistant.io/developers/rest_api/#post-apiservicesltdomainltservice</a>
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <param name="service">The service name.</param>
        /// <param name="serviceData">The service data. Should include entity_id, unless you want to call the service on all entities in the domain.</param>
        /// <returns>The <see cref="EntityState"/>[] for each entity that had its state changed while this service was called.</returns>
        public async Task<EntityState[]> CallServiceAsync(string domain, string service, object serviceData)
        {
            var url = $"{_hassUrl}{domain}/{service}";
            var json = JsonConvert.SerializeObject(new
            {
                serviceData
            });
            var resp = await _client.PostAsync(url, new StringContent(json));
            var respStr = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<EntityState[]>(respStr);
        }

        /// <summary>
        /// Calls a service.<para />
        /// Note: The result will include any changed states that changed while the service was being executed, even if their change was the result of something else happening in the system.<para />
        /// See more: <a href="https://home-assistant.io/developers/rest_api/#post-apiservicesltdomainltservice">https://home-assistant.io/developers/rest_api/#post-apiservicesltdomainltservice</a>
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="fields">The fields/parameters for the service.</param>
        /// <returns>The <see cref="EntityState"/>[] for each entity that had its state changed while this service was called.</returns>
        public Task<EntityState[]> CallServiceAsync(Service service, string entityId,
            Dictionary<string, object> fields)
        {
            if (!fields.ContainsKey("entity_id") && !string.IsNullOrEmpty(entityId))
                fields.Add("entity_id", entityId);
            return CallServiceAsync(service.Domain, service.ServiceName, fields);
        }

        /// <summary>
        /// Runs the template.
        /// </summary>
        /// <param name="template">The template. For example: "Paulus is at {{ states('device_tracker.paulus') }}!"</param>
        /// <returns>A <see cref="string"/> with the resulting text. For example: Paulus is at work!</returns>
        public async Task<string> RunTemplate(string template)
        {
            var url = $"{_hassUrl}template";
            var json = JsonConvert.SerializeObject(new
            {
                template
            });
            var resp = await _client.PostAsync(url, new StringContent(json));
            var respStr = await resp.Content.ReadAsStringAsync();
            return respStr;
        }

        /// <summary>
        /// Add event forwarding to another HA instance.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="apiPassword">The API password.</param>
        /// <param name="port">The port. (Optional)</param>
        /// <returns>A simple <see cref="MessageResponse"/> with a message saying the event forwarding is set up.</returns>
        public async Task<MessageResponse> AddEventForwarding(string host, string apiPassword, int? port)
        {
            var url = $"{_hassUrl}event_forwarding";
            var json = JsonConvert.SerializeObject(new
            {
                host,
                api_password = apiPassword,
                port
            }, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            var resp = await _client.PostAsync(url, new StringContent(json));
            var respStr = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MessageResponse>(respStr);
        }

        /// <summary>
        /// Deletes the event forwarding.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="apiPassword">The API password.</param>
        /// <param name="port">The port. (Optional)</param>
        /// <returns>A simple <see cref="MessageResponse"/> with a message saying the event forwarding is deleted.</returns>
        public async Task<MessageResponse> DeleteEventForwarding(string host, string apiPassword, int? port)
        {
            var url = $"{_hassUrl}event_forwarding";
            var json = JsonConvert.SerializeObject(new
            {
                host,
                api_password = apiPassword,
                port,
                _METHOD = "DELETE"
            }, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            var resp = await _client.PostAsync(url, new StringContent(json));
            var respStr = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MessageResponse>(respStr);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
