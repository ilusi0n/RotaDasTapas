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
            client.BaseAddress = new Uri("http://localhost:5001");
            base.ConfigureClient(client);
        }
    }
}