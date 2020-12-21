using Moq;
using ProjetoMvp.CommerceContext.Domain.Commands;
using ProjetoMvp.CommerceContext.Domain.Handlers;
using ProjetoMvp.CommerceContext.Domain.Repositories;
using System.Linq;
using Xunit;

namespace ProjetoMvp.Tests.Unit.CommerceContext.Handlers
{
    public class CommerceHandlerTests
    {
        private readonly Mock<ICommerceRepository> _mockCommerceRepository;

        public CommerceHandlerTests()
        {
            _mockCommerceRepository = new Mock<ICommerceRepository>();
        }

        [Fact]
        public void Should_return_success()
        {
            var handler = new CommerceHandler(_mockCommerceRepository.Object);

            var command = new CreateCommerceCommand
            {
                Name = "Test Name",
                SiteDomain = "test.com",
                Country = "Brasil",
                State = "São Paulo",
                City = "São Paulo"
            };

            var result = handler.Handle(command);

            Assert.True(result.Success);
            Assert.True(handler.Valid);
        }

        [Fact]
        public void Should_return_error_when_command_is_invalid()
        {
            var handler = new CommerceHandler(_mockCommerceRepository.Object);

            var command = new CreateCommerceCommand();

            var result = handler.Handle(command);

            Assert.False(command.Valid);
            Assert.False(handler.Valid);
            Assert.False(result.Success);
        }

        [Fact]
        public void Should_return_error_when_name_exists()
        {
            _mockCommerceRepository.Setup(x => x.NameExists(It.IsAny<string>()))
                .Returns(true);

            var handler = new CommerceHandler(_mockCommerceRepository.Object);

            var command = new CreateCommerceCommand
            {
                Name = "Test Name",
                SiteDomain = "test.com",
                Country = "Brasil",
                State = "São Paulo",
                City = "São Paulo"
            };

            var result = handler.Handle(command);

            Assert.False(handler.Valid);
            Assert.False(result.Success);
            Assert.Equal("Name", handler.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "Name"));
        }

        [Fact]
        public void Should_return_error_when_domain_exists()
        {
            _mockCommerceRepository.Setup(x => x.NameExists(It.IsAny<string>()))
                .Returns(false);
            _mockCommerceRepository.Setup(x => x.DomainExists(It.IsAny<string>()))
                .Returns(true);

            var handler = new CommerceHandler(_mockCommerceRepository.Object);

            var command = new CreateCommerceCommand
            {
                Name = "Test Name",
                SiteDomain = "test.com",
                Country = "Brasil",
                State = "São Paulo",
                City = "São Paulo"
            };

            var result = handler.Handle(command);

            Assert.False(handler.Valid);
            Assert.False(result.Success);
            Assert.Equal("Domain", handler.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "Domain"));
        }
    }
}
