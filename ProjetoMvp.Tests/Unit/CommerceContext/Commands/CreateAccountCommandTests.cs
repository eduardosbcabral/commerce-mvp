using ProjetoMvp.CommerceContext.Domain.Commands;
using System.Linq;
using Xunit;

namespace ProjetoMvp.Tests.Unit.CommerceContext.Commands
{
    public class CreateAccountCommandTests
    {
        private readonly int _age;
        private readonly string _email;
        private readonly string _password;

        public CreateAccountCommandTests()
        {
            _age = 18;
            _email = "test@test.com";
            _password = "password";
        }

        [Fact]
        public void Should_be_valid_when_input_is_valid()
        {
            var command = new CreateAccountCommand()
            {
                Age = _age,
                Email = _email,
                Password = _password
            };

            command.Validate();

            Assert.True(command.Valid);
        }

        [Fact]
        public void Should_be_invalid_when_email_is_invalid()
        {
            var command = new CreateAccountCommand()
            {
                Age = _age,
                Email = string.Empty,
                Password = _password
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Contains("Email", command.Notifications
                .Select(x => x.Property));
        }

        [Fact]
        public void Should_be_invalid_when_age_is_lesser_than_eighteen()
        {
            var command = new CreateAccountCommand()
            {
                Age = 16,
                Email = _email,
                Password = _password
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Contains("Age", command.Notifications
                .Select(x => x.Property));
        }

        [Fact]
        public void Should_be_invalid_when_password_is_lesser_than_four_characters()
        {
            var command = new CreateAccountCommand()
            {
                Age = _age,
                Email = _email,
                Password = "pas"
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Contains("Password", command.Notifications
                .Select(x => x.Property));
        }

        [Fact]
        public void Should_be_invalid_when_password_is_greater_than_128_characters()
        {
            var command = new CreateAccountCommand()
            {
                Age = _age,
                Email = _email,
                Password = new string('p', 129)
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Contains("Password", command.Notifications
                .Select(x => x.Property));
        }

        [Fact]
        public void Should_be_invalid_when_password_is_null()
        {
            var command = new CreateAccountCommand()
            {
                Age = _age,
                Email = _email,
                Password = null
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Contains("Password", command.Notifications
                .Select(x => x.Property));
        }

        [Fact]
        public void Should_be_invalid_when_password_is_empty()
        {
            var command = new CreateAccountCommand()
            {
                Age = _age,
                Email = _email,
                Password = string.Empty
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Contains("Password", command.Notifications
                .Select(x => x.Property));
        }
    }
}
