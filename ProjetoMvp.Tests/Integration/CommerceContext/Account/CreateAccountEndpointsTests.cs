using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjetoMvp.Api;
using ProjetoMvp.CommerceContext.Domain.Commands;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjetoMvp.Tests.Integration.CommerceContext.Accounts
{
    public class CreateAccountEndpointsTests : IntegrationTestsBase
    {
        public CreateAccountEndpointsTests(CustomWebApplicationFactory<Startup> factory)
            : base(factory)
        {
        }

        [Theory]
        [InlineData("/accounts")]
        public async Task Create_account_should_return_success(string url)
        {
            var body = new CreateAccountCommand()
            {
                Age = 18,
                Email = "test12345@test.com",
                Password = "password"
            };

            var stringBody = JsonConvert.SerializeObject(body);

            var stringContent = new StringContent(stringBody, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(url, stringContent);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            dynamic result = JObject.Parse(jsonResponse);

            Assert.True((bool)result.success, (string)result.message);
            Assert.Equal("Conta cadastrada com sucesso.", (string)result.message);
        }
    }
}
