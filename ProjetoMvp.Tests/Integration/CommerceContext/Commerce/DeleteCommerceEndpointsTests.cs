using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjetoMvp.Api;
using ProjetoMvp.CommerceContext.Domain.Commands;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjetoMvp.Tests.Integration.CommerceContext.Commerces
{
    public class DeleteCommerceEndpointsTests : IntegrationTestsBase
    {
        public DeleteCommerceEndpointsTests(CustomWebApplicationFactory<Startup> factory)
            : base(factory)
        {
        }

        [Theory]
        [InlineData("/commerces")]
        public async Task Delete_commerce_should_return_success(string url)
        {
            var bodyCreate = new CreateCommerceCommand()
            {
                Name = "CommerceName1234",
                Country = "Brazil",
                State = "São Paulo",
                City = "São Paulo",
                SiteDomain = "testdomain1234"
            };

            var stringBody = JsonConvert.SerializeObject(bodyCreate);

            var stringContent = new StringContent(stringBody, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(url, stringContent);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            dynamic result = JObject.Parse(jsonResponse);

            var entityId = result.result.id;

            response = await _client.DeleteAsync($"{url}/{entityId}");

            response.EnsureSuccessStatusCode();

            jsonResponse = await response.Content.ReadAsStringAsync();

            result = JObject.Parse(jsonResponse);

            // Assert
            Assert.True((bool)result.success, (string)result.message);
            Assert.Equal("Comércio removido com sucesso.", (string)result.message);
        }

        [Theory]
        [InlineData("/commerces")]
        public async Task Delete_commerce_should_return_bad_request_when_id_is_invalid(string url)
        {
            var entityId = 123;

            var response = await _client.DeleteAsync($"{url}/{entityId}");

            var jsonResponse = await response.Content.ReadAsStringAsync();

            dynamic result = JObject.Parse(jsonResponse);

            // Assert
            Assert.False((bool)result.success, (string)result.message);
            Assert.Equal("Não foi possível remover o comércio.", (string)result.message);
            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)result.statusCode);
        }

        [Theory]
        [InlineData("/commerces")]
        public async Task Delete_commerce_should_return_not_found_when_commerce_is_not_found(string url)
        {
            var entityId = Guid.NewGuid();

            var response = await _client.DeleteAsync($"{url}/{entityId}");

            var jsonResponse = await response.Content.ReadAsStringAsync();

            dynamic result = JObject.Parse(jsonResponse);

            // Assert
            Assert.False((bool)result.success, (string)result.message);
            Assert.Equal("Não foi possível encontrar o comércio.", (string)result.message);
            Assert.Equal(HttpStatusCode.NotFound, (HttpStatusCode)result.statusCode);
        }
    }
}
