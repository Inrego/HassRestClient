using System;
using HassRestClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HassRestClient
{
    internal class ServiceConverter : CustomCreationConverter<ServiceDomain>
    {
        public override ServiceDomain Create(Type objectType)
        {
            return (ServiceDomain) Activator.CreateInstance(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var service = (ServiceDomain) base.ReadJson(reader, objectType, existingValue, serializer);
            if (service.Services != null)
            {
                foreach (var serviceService in service.Services)
                {
                    serviceService.Value.Domain = service.Domain;
                    serviceService.Value.ServiceName = serviceService.Key;
                }
            }
            return service;
        }
    }
}
