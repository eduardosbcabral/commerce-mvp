﻿using Moq;
using ProjetoMvp.CommerceContext.Domain.Commands;
using ProjetoMvp.CommerceContext.Domain.Entities;
using ProjetoMvp.CommerceContext.Domain.Handlers;
using ProjetoMvp.CommerceContext.Domain.Repositories;
using ProjetoMvp.CommerceContext.Domain.ValueObjects;
using System;
using Xunit;

namespace ProjetoMvp.Tests.Unit.CommerceContext.Handlers
{
    public class UpdateCommerceHandlerTests
    {
        private readonly Mock<ICommerceRepository> _mockCommerceRepository;
        private readonly Mock<ISiteRepository> _mockSiteRepository;

        public UpdateCommerceHandlerTests()
        {
            _mockCommerceRepository = new Mock<ICommerceRepository>();
            _mockSiteRepository = new Mock<ISiteRepository>();
        }

        [Fact]
        public void Should_return_success()
        {
            var commerceMock = new Mock<Commerce>("name", new Mock<Site>().Object, new Mock<Address>().Object);
            _mockCommerceRepository.Setup(x => x.NameExists(It.IsAny<string>(), It.IsAny<Guid>()))
                .Returns(false);
            _mockCommerceRepository.Setup(x => x.DomainExists(It.IsAny<string>(), It.IsAny<Guid>()))
                .Returns(false);
            _mockCommerceRepository.Setup(x => x.GetById(It.IsAny<Guid>()))
              .Returns(commerceMock.Object);

            var handler = new UpdateCommerceHandler(_mockCommerceRepository.Object);

            var command = new UpdateCommerceCommand
            {
                Id = Guid.NewGuid(),
                Name = "Test Name",
                SiteDomain = "test.com",
                Country = "Brasil",
                State = "São Paulo",
                City = "São Paulo"
            };

            var result = handler.Handle(command);

            Assert.True(result.Success, result.Message);
            Assert.True(handler.Valid);
        }

        [Fact]
        public void Should_return_error_when_command_is_invalid()
        {
            var handler = new UpdateCommerceHandler(_mockCommerceRepository.Object);

            var command = new UpdateCommerceCommand();

            var result = handler.Handle(command);

            Assert.False(command.Valid);
            Assert.False(handler.Valid);
            Assert.False(result.Success);
        }

        [Fact]
        public void Should_return_error_when_name_exists()
        {
            _mockCommerceRepository.Setup(x => x.NameExists(It.IsAny<string>(), It.IsAny<Guid>()))
                .Returns(true);

            var handler = new UpdateCommerceHandler(_mockCommerceRepository.Object);

            var command = new UpdateCommerceCommand
            {
                Id = Guid.NewGuid(),
                Name = "Test Name",
                SiteDomain = "test.com",
                Country = "Brasil",
                State = "São Paulo",
                City = "São Paulo"
            };

            var result = handler.Handle(command);

            Assert.False(handler.Valid);
            Assert.False(result.Success);
            Assert.Contains(handler.Notifications, x => x.Property == "Name");
        }

        [Fact]
        public void Should_return_error_when_domain_exists()
        {
            _mockCommerceRepository.Setup(x => x.NameExists(It.IsAny<string>(), It.IsAny<Guid>()))
                .Returns(false);
            _mockCommerceRepository.Setup(x => x.DomainExists(It.IsAny<string>(), It.IsAny<Guid>()))
                .Returns(true);

            var handler = new UpdateCommerceHandler(_mockCommerceRepository.Object);

            var command = new UpdateCommerceCommand
            {
                Id = Guid.NewGuid(),
                Name = "Test Name",
                SiteDomain = "test.com",
                Country = "Brasil",
                State = "São Paulo",
                City = "São Paulo"
            };

            var result = handler.Handle(command);

            Assert.False(handler.Valid);
            Assert.False(result.Success);
            Assert.Contains(handler.Notifications, x => x.Property == "Domain");
        }
    }
}
