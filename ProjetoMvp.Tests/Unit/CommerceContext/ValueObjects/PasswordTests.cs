using ProjetoMvp.CommerceContext.Domain.ValueObjects;
using System.Linq;
using Xunit;

namespace ProjetoMvp.Tests.Unit.CommerceContext.ValueObjects
{
    public class PasswordTests
    {
        [Fact]
        public void Should_be_valid()
        {
            var password = new Password("password");
            Assert.True(password.Valid);
        }

        [Fact]
        public void Should_be_invalid_when_password_is_lesser_than_four_characters()
        {
            var password = new Password("pas");
            Assert.True(password.Invalid);
            Assert.Contains("Password", password.Notifications.Select(x => x.Property));
        }

        [Fact]
        public void Should_be_invalid_when_password_is_greater_than_128_characters()
        {
            var password = new Password(new string('p', 129));
            Assert.True(password.Invalid);
            Assert.Contains("Password", password.Notifications.Select(x => x.Property));
        }

        [Fact]
        public void Verification_should_be_true_when_password_is_correct()
        {
            var password = new Password("password");
            var verification = password.Verify("password");
            Assert.True(verification);
        }

        [Fact]
        public void Verification_should_be_false_when_password_is_incorrect()
        {
            var password = new Password("password");
            var verification = password.Verify("wrong");
            Assert.False(verification);
        }
    }
}
