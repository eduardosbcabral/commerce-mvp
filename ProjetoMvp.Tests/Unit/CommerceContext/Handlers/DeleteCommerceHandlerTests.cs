using Moq;
using ProjetoMvp.CommerceContext.Domain.Commands;
using ProjetoMvp.CommerceContext.Domain.Entities;
using ProjetoMvp.CommerceContext.Domain.Handlers;
using ProjetoMvp.CommerceContext.Domain.Repositories;
using System;
using Xunit;

namespace ProjetoMvp.Tests.Unit.CommerceContext.Handlers
{
    public class DeleteCommerceHandlerTests
    {
        private readonly Mock<ICommerceRepository> _commerceRepositoryMock;

        public DeleteCommerceHandlerTests()
        {
            _commerceRepositoryMock = new Mock<ICommerceRepository>();
        }

        [Fact]
        public void Should_return_success()
        {
            _commerceRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
                .Returns(new Commerce());

            var command = new DeleteCommerceCommand()
            {
                Id = Guid.NewGuid()
            };

            var handler = new DeleteCommerceHandler(_commerceRepositoryMock.Object);

            var result = handler.Handle(command);

            Assert.True(result.Success);
        }

        [Fact]
        public void Should_return_error_when_command_is_invalid()
        {
            var command = new DeleteCommerceCommand();

            var handler = new DeleteCommerceHandler(_commerceRepositoryMock.Object);

            var result = handler.Handle(command);

            Assert.False(result.Success);
            Assert.Equal("Não foi possível remover o comércio.", result.Message);
            Assert.Contains(handler.Notifications, x => x.Property == "Id");
        }

        [Fact]
        public void Should_return_not_found_when_commerce_is_not_found()
        {
            _commerceRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
                .Returns(() => null);

            var command = new DeleteCommerceCommand()
            {
                Id = Guid.NewGuid()
            };

            var handler = new DeleteCommerceHandler(_commerceRepositoryMock.Object);

            var result = handler.Handle(command);

            Assert.False(result.Success, result.Message);
            Assert.Equal("Não foi possível encontrar o comércio.", result.Message);
        }
    }
}
