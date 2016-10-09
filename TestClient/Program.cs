using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HassRestClient;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = @"http://192.168.0.21:8123/";
            var password = "63901113";
            using (var client = new ApiClient(url, password))
            {
                var resp = client.GetBootstrapAsync().GetAwaiter().GetResult();
                Debugger.Break();
            }
        }
    }
}
