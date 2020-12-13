using ProjetoMvp.Api.Models;
using System.Linq;
using Xunit;

namespace ProjetoMvp.Tests.Models
{
    public class EmailTests
    {
        private const string _valid_email = "test@test.com";

        [Fact]
        public void Should_validate_input_correctly()
        {
            var email = new Email(_valid_email);
            Assert.True(email.Valid);
        }

        [Fact]
        public void Should_be_invalid_when_value_is_null()
        {
            var email = new Email(null);
            Assert.True(email.Invalid);
            Assert.Equal("Email.Address", email.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "Email.Address"));
        }

        [Fact]
        public void Should_be_invalid_when_value_is_not_an_email()
        {
            var email = new Email("notemail@abc");
            Assert.True(email.Invalid);
            Assert.Equal("Email.Address", email.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "Email.Address"));
        }
    }
}
