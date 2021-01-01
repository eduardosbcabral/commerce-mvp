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
    public class UpdateCommerceEndpointsTests : IntegrationTestsBase
    {
        public UpdateCommerceEndpointsTests(CustomWebApplicationFactory<Startup> factory) 
            : base(factory)
        {
        }

        [Theory]
        [InlineData("/commerces")]
        public async Task Update_commerce_should_return_success(string url)
        {
            var bodyCreate = new CreateCommerceCommand()
            {
                Name = "CommerceName123",
                Country = "Brazil",
                State = "São Paulo",
                City = "São Paulo",
                SiteDomain = "testdomain"
            };

            var stringBodyCreate = JsonConvert.SerializeObject(bodyCreate);

            var stringContentCreate = new StringContent(stringBodyCreate, Encoding.UTF8, "application/json");

            var responseCreate = await _client.PostAsync(url, stringContentCreate);

            responseCreate.EnsureSuccessStatusCode();

            var jsonResponseCreate = await responseCreate.Content.ReadAsStringAsync();

            dynamic resultCreate = JObject.Parse(jsonResponseCreate);

            var entityId = (Guid)resultCreate.result.id;

            var bodyUpdate = new UpdateCommerceCommand()
            {
                Name = "CommerceName123",
                Country = "test",
                State = "São Paulo",
                City = "São Paulo",
                SiteDomain = "testdomain123"
            };

            var stringBodyUpdate = JsonConvert.SerializeObject(bodyUpdate);

            var stringContentUpdate = new StringContent(stringBodyUpdate, Encoding.UTF8, "application/json");

            var responseUpdate = await _client.PatchAsync($"{url}/{entityId}", stringContentUpdate);

            responseUpdate.EnsureSuccessStatusCode();

            var jsonResponseUpdate = await responseUpdate.Content.ReadAsStringAsync();

            dynamic resultUpdate = JObject.Parse(jsonResponseUpdate);

            // Assert
            Assert.True((bool)resultUpdate.success, (string)resultUpdate.message);
            Assert.Equal("Comércio atualizado com sucesso.", (string)resultUpdate.message);
        }

        [Theory]
        [InlineData("/commerces")]
        public async Task Update_commerce_should_return_bad_request_when_command_is_invalid(string url)
        {
            var entityId = Guid.NewGuid();

            var body = new UpdateCommerceCommand()
            {
                Name = "",
                Country = "test",
                State = "São Paulo",
                City = "São Paulo",
                SiteDomain = "testdomain123"
            };

            var stringBody = JsonConvert.SerializeObject(body);

            var stringContent = new StringContent(stringBody, Encoding.UTF8, "application/json");

            var response = await _client.PatchAsync($"{url}/{entityId}", stringContent);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            dynamic result = JObject.Parse(jsonResponse);

            // Assert
            Assert.False((bool)result.success);
            Assert.Equal("Não foi possível atualizar o comércio.", (string)result.message);
            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)result.statusCode);
        }

        [Theory]
        [InlineData("/commerces")]
        public async Task Update_commerce_should_return_not_found_when_commerce_is_not_found(string url)
        {
            var entityId = Guid.NewGuid();

            var body = new UpdateCommerceCommand()
            {
                Name = "CommerceName1238974641",
                Country = "test",
                State = "São Paulo",
                City = "São Paulo",
                SiteDomain = "testdomain8974641"
            };

            var stringBody = JsonConvert.SerializeObject(body);

            var stringContent = new StringContent(stringBody, Encoding.UTF8, "application/json");

            var response = await _client.PatchAsync($"{url}/{entityId}", stringContent);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            dynamic result = JObject.Parse(jsonResponse);

            // Assert
            Assert.False((bool)result.success);
            Assert.Equal("Não foi possível atualizar o comércio.", (string)result.message);
            Assert.Equal(HttpStatusCode.NotFound, (HttpStatusCode)result.statusCode);
        }
    }
}
