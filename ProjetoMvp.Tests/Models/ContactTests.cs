using ProjetoMvp.Api.Models;
using System;
using System.Linq;
using Xunit;

namespace ProjetoMvp.Tests.Models
{
    public class ContactTests
    {
        private readonly Email _email = new Email("test@test.com");
        private readonly Phone _phone = new Phone("061", "999999999");

        [Fact]
        public void Should_generate_id_after_being_initialized_correctly()
        {
            var contact = new Contact(_email, _phone);
            Assert.True(contact.Id != Guid.Empty);
        }

        [Fact]
        public void Should_not_define_property_values_when_invalid()
        {
            var contact = new Contact(null, _phone);
            Assert.Null(contact.Email);
            Assert.Null(contact.Phone);
        }

        [Fact]
        public void Should_be_invalid_when_email_is_null()
        {
            var contact = new Contact(null, _phone);
            Assert.True(contact.Invalid);
            Assert.Equal("Email", contact.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "Email"));
        }

        [Fact]
        public void Should_be_invalid_when_phone_is_null()
        {
            var contact = new Contact(_email, null);
            Assert.True(contact.Invalid);
            Assert.Equal("Phone", contact.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "Phone"));
        }
    }
}
