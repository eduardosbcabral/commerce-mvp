using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using ProjetoMvp.Api;
using ProjetoMvp.CommerceContext.Domain.Commands;
using ProjetoMvp.Shared.Domain.Handlers;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjetoMvp.Tests.Integration.CommerceContext.Handlers
{
    public class CreateCommerceCommandTests : IntegrationTestsBase
    {
        public CreateCommerceCommandTests(CustomWebApplicationFactory<Startup> factory) 
            : base(factory)
        {
        }

        [Theory]
        [InlineData("/commerces")]
        public async Task Create_commerce_should_return_success(string url)
        {
            var body = new CreateCommerceCommand()
            {
                Name = "CommerceName",
                Country = "Brazil",
                State = "São Paulo",
                City = "São Paulo",
                SiteDomain = "testdomain"
            };

            var stringBody = JsonConvert.SerializeObject(body);

            var stringContent = new StringContent(stringBody, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync(url, stringContent);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            dynamic result = JObject.Parse(jsonResponse);

            // Assert
            Assert.True((bool)result.success, (string)result.message);
            Assert.Equal("Comércio cadastrado com sucesso.", (string)result.message);
            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [InlineData("/commerces")]
        public async Task Create_commerce_should_return_bad_request_when_command_is_invalid(string url)
        {
            var body = new CreateCommerceCommand()
            {
                Name = "",
                Country = "",
                State = "",
                City = "",
                SiteDomain = ""
            };

            var stringBody = JsonConvert.SerializeObject(body);

            var stringContent = new StringContent(stringBody, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync(url, stringContent);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            dynamic result = JObject.Parse(jsonResponse);

            // Assert
            Assert.False((bool)result.success, (string)result.message);
            Assert.Equal("Não foi possível cadastrar o comércio.", (string)result.message);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
