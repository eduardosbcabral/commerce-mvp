using Moq;
using ProjetoMvp.CommerceContext.Domain.Commands;
using ProjetoMvp.CommerceContext.Domain.Handlers;
using ProjetoMvp.CommerceContext.Domain.Repositories;
using System.Linq;
using Xunit;

namespace ProjetoMvp.Tests.Unit.CommerceContext.Handlers
{
    public class CreateAccountHandlerTests
    {
        private readonly Mock<IAccountRepository> _mockAccountRepository;

        public CreateAccountHandlerTests()
        {
            _mockAccountRepository = new Mock<IAccountRepository>();
        }

        [Fact]
        public void Should_return_success()
        {
            var handler = new CreateAccountHandler(_mockAccountRepository.Object);

            var command = new CreateAccountCommand()
            {
                Age = 18,
                Email = "test123@test.com",
                Password = "password"
            };

            var result = handler.Handle(command);

            Assert.True(result.Success);
            Assert.True(handler.Valid);
        }

        [Fact]
        public void Should_return_error_when_command_is_invalid()
        {
            var handler = new CreateAccountHandler(_mockAccountRepository.Object);

            var command = new CreateAccountCommand();

            var result = handler.Handle(command);

            Assert.False(command.Valid);
            Assert.False(handler.Valid);
            Assert.False(result.Success);
        }

        [Fact]
        public void Should_return_error_when_email_exists()
        {
            _mockAccountRepository.Setup(x => x.EmailExists(It.IsAny<string>(), null))
                .Returns(true);

            var handler = new CreateAccountHandler(_mockAccountRepository.Object);

            var command = new CreateAccountCommand()
            {
                Age = 18,
                Email = "test12@test.com",
                Password = "password"
            };

            var result = handler.Handle(command);

            Assert.False(handler.Valid);
            Assert.False(result.Success);
            Assert.Contains("Email", handler.Notifications.Select(x => x.Property));
        }
    }
}
