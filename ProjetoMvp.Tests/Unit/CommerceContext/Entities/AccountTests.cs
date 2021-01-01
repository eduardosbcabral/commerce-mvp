using ProjetoMvp.CommerceContext.Domain.Entities;
using ProjetoMvp.CommerceContext.Domain.ValueObjects;
using System;
using System.Linq;
using Xunit;

namespace ProjetoMvp.Tests.Unit.CommerceContext.Entities
{
    public class AccountTests
    {
        private readonly Age _age;
        private readonly Email _email;
        private readonly Password _password;

        public AccountTests()
        {
            _age = new Age(18);
            _email = new Email("test@test.com");
            _password = new Password("password");
        }

        [Fact]
        public void Should_generate_id_after_being_initialized_correctly()
        {
            var account = new Account(_age, _email, _password);
            Assert.True(account.Id != Guid.Empty);
        }

        [Fact]
        public void Should_not_define_property_values_when_invalid()
        {
            var account = new Account(_age, null, _password);
            Assert.Null(account.Email);
        }

        [Fact]
        public void Should_be_invalid_when_email_is_null()
        {
            var account = new Account(_age, null, _password);
            Assert.True(account.Invalid);
            Assert.Contains("Email", account.Notifications
                .Select(x => x.Property));
        }

        [Fact]
        public void Should_be_invalid_when_email_is_invalid()
        {
            var email = new Email("");
            var account = new Account(_age, email, _password);
            Assert.True(account.Invalid);
            Assert.Contains("Email.Address", account.Notifications
                .Select(x => x.Property));
        }

        [Fact]
        public void Should_be_invalid_when_password_is_null()
        {
            var account = new Account(_age, _email, null);
            Assert.True(account.Invalid);
            Assert.Contains("Password", account.Notifications
                .Select(x => x.Property));
        }

        [Fact]
        public void Should_be_invalid_when_password_is_invalid()
        {
            var password = new Password("");
            var account = new Account(_age, _email, password);
            Assert.True(account.Invalid);
            Assert.Contains("Password.Value", account.Notifications
                .Select(x => x.Property));
        }
    }
}
