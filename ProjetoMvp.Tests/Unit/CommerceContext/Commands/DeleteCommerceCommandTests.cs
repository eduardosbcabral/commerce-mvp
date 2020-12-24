using ProjetoMvp.CommerceContext.Domain.Commands;
using System;
using Xunit;

namespace ProjetoMvp.Tests.Unit.CommerceContext.Commands
{
    public class DeleteCommerceCommandTests
    {
        [Fact]
        public void Should_be_valid()
        {
            var command = new DeleteCommerceCommand()
            {
                Id = Guid.NewGuid()
            };

            command.Validate();

            Assert.True(command.Valid);
        }

        [Fact]
        public void Should_be_invalid_when_id_is_empty()
        {
            var command = new DeleteCommerceCommand()
            {
                Id = Guid.Empty
            };

            command.Validate();

            Assert.False(command.Valid);
        }
    }
}
