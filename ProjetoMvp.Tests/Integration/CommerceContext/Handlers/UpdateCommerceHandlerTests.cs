using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjetoMvp.Api;
using ProjetoMvp.CommerceContext.Domain.Commands;
using ProjetoMvp.Shared.Domain.Handlers;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjetoMvp.Tests.Integration.CommerceContext.Handlers
{
    public class UpdateCommerceHandlerTests : IntegrationTestsBase
    {
        public UpdateCommerceHandlerTests(CustomWebApplicationFactory<Startup> factory) 
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

        //[Theory]
        //[InlineData("/commerces")]
        //public async Task Create_commerce_should_return_bad_request_when_command_is_invalid(string url)
        //{
        //    // Arrange
        //    var client = _factory.CreateClient();

        //    var body = new CreateCommerceCommand()
        //    {
        //        Name = "",
        //        Country = "",
        //        State = "",
        //        City = "",
        //        SiteDomain = ""
        //    };

        //    //var stringBody = JsonSerializer.Serialize(body);

        //    //var stringContent = new StringContent(stringBody, Encoding.UTF8, "application/json");

        //    //// Act
        //    //var response = await client.PostAsync(url, stringContent);

        //    //var jsonResponse = await response.Content.ReadAsStringAsync();

        //    //var result = JsonSerializer.Deserialize<CommandResult>(jsonResponse, new JsonSerializerOptions
        //    //{
        //    //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        //    //});

        //    //// Assert
        //    //Assert.False(result.Success);
        //    //Assert.Equal("Não foi possível cadastrar o comércio.", result.Message);
        //    //Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        //}
    }
}
