using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace RotaDasTapas.Integration.Tests.Helpers
{
    public class CustomWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureClient(HttpClient client)
        {
            client.DefaultRequestHeaders.Add("BMW-Correlation-ID", "10000000-0000-0000-0000-000000000002");
            client.DefaultRequestHeaders.Add("BMW-SCS-Search-Configuration", "crypto-string");
            client.BaseAddress = new Uri("http://localhost:5001");
            base.ConfigureClient(client);
        }
    }
}