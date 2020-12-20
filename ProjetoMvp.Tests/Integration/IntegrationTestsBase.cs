using Microsoft.AspNetCore.Mvc.Testing;
using ProjetoMvp.Api;
using System.Net.Http;
using Xunit;

namespace ProjetoMvp.Tests.Integration
{
    public class IntegrationTestsBase : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        protected readonly HttpClient _client;
        protected readonly CustomWebApplicationFactory<Startup> _factory;

        public IntegrationTestsBase(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }
    }
}
