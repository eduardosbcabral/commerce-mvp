using Microsoft.AspNetCore.Mvc.Testing;
using ProjetoMvp.Api;
using ProjetoMvp.CommerceContext.Domain.Commands;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
        public async Task Get_all_commerce_should_return_success(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [InlineData("/commerces")]
        public async Task Create_commerce_should_return_success(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            var body = new CreateCommerceCommand()
            {
                Name = "CommerceName",
                Country = "Brazil",
                State = "São Paulo",
                City = "São Paulo",
                SiteDomain = "testdomain"
            };

            var stringBody = JsonSerializer.Serialize(body);

            var stringContent = new StringContent(stringBody, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync(url, stringContent);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<CommandResult>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            // Assert
            Assert.True(result.Success, result.Message);
            Assert.Equal("Comércio cadastrado com sucesso.", result.Message);
            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [InlineData("/commerces")]
        public async Task Create_commerce_should_return_bad_request_when_command_is_invalid(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            var body = new CreateCommerceCommand()
            {
                Name = "",
                Country = "",
                State = "",
                City = "",
                SiteDomain = ""
            };

            var stringBody = JsonSerializer.Serialize(body);

            var stringContent = new StringContent(stringBody, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync(url, stringContent);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<CommandResult>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Não foi possível cadastrar o comércio.", result.Message);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
