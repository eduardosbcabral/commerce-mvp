using ProjetoMvp.CommerceContext.Domain.Commands;
using System;
using System.Linq;
using Xunit;

namespace ProjetoMvp.Tests.Unit.CommerceContext.Commands
{
    public class UpdateCommerceCommandTests
    {
        private const string _valid_name = "Test Name";
        private const string _valid_domain = "test.com";

        private const string _valid_country = "Brasil";
        private const string _valid_state = "São Paulo";
        private const string _valid_city = "São Paulo";
        private const string _valid_zipcode = "11111111";
        private const string _valid_street = "street";

        [Fact]
        public void Should_be_valid()
        {
            var command = new UpdateCommerceCommand
            {
                Id = Guid.NewGuid(),
                SiteId = Guid.NewGuid(),
                Name = _valid_name,
                SiteDomain = _valid_domain,
                Country = _valid_country,
                State = _valid_state,
                City = _valid_city
            };

            command.Validate();

            Assert.True(command.Valid);
        }

        [Fact]
        public void Should_be_invalid_when_id_is_empty()
        {
            var command = new UpdateCommerceCommand
            {
                Id = Guid.Empty
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Contains(command.Notifications, x => x.Property == "Id");
        }

        [Fact]
        public void Should_be_invalid_when_name_is_empty()
        {
            var command = new UpdateCommerceCommand
            {
                Name = ""
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Equal("Name", command.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "Name"));
        }

        [Fact]
        public void Should_be_invalid_when_name_is_null()
        {
            var command = new UpdateCommerceCommand
            {
                Name = null
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Equal("Name", command.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "Name"));
        }

        [Fact]
        public void Should_be_invalid_when_name_does_not_has_min_length_3_chars()
        {
            var command = new UpdateCommerceCommand
            {
                Name = "a"
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Equal("Name", command.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "Name"));
        }

        [Fact]
        public void Should_be_invalid_when_name_surpass_max_length_50_chars()
        {
            var command = new UpdateCommerceCommand
            {
                Name = new string('a', 51)
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Equal("Name", command.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "Name"));
        }

        [Fact]
        public void Should_be_invalid_when_site_id_is_empty()
        {
            var command = new UpdateCommerceCommand
            {
                SiteId = Guid.Empty
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Contains(command.Notifications, x => x.Property == "Id");
        }

        [Fact]
        public void Should_be_invalid_when_site_domain_is_empty()
        {
            var command = new UpdateCommerceCommand
            {
                SiteDomain = ""
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Equal("SiteDomain", command.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "SiteDomain"));
        }

        [Fact]
        public void Should_be_invalid_when_site_domain_is_null()
        {
            var command = new UpdateCommerceCommand
            {
                SiteDomain = null
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Equal("SiteDomain", command.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "SiteDomain"));
        }

        [Fact]
        public void Should_be_invalid_when_country_is_empty()
        {
            var command = new UpdateCommerceCommand
            {
                Country = ""
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Equal("Country", command.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "Country"));
        }

        [Fact]
        public void Should_be_invalid_when_country_is_null()
        {
            var command = new UpdateCommerceCommand
            {
                Country = null
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Equal("Country", command.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "Country"));
        }

        [Fact]
        public void Should_be_invalid_when_country_does_not_has_min_length_3_chars()
        {
            var command = new UpdateCommerceCommand
            {
                Country = "a"
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Equal("Country", command.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "Country"));
        }

        [Fact]
        public void Should_be_invalid_when_country_surpass_max_length_50_chars()
        {
            var command = new UpdateCommerceCommand
            {
                Country = new string('a', 51)
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Equal("Country", command.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "Country"));
        }

        [Fact]
        public void Should_be_invalid_when_state_is_empty()
        {
            var command = new UpdateCommerceCommand
            {
                State = ""
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Equal("State", command.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "State"));
        }

        [Fact]
        public void Should_be_invalid_when_state_is_null()
        {
            var command = new UpdateCommerceCommand
            {
                State = null
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Equal("State", command.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "State"));
        }

        [Fact]
        public void Should_be_invalid_when_state_does_not_has_min_length_3_chars()
        {
            var command = new UpdateCommerceCommand
            {
                State = "a"
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Equal("State", command.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "State"));
        }

        [Fact]
        public void Should_be_invalid_when_state_surpass_max_length_50_chars()
        {
            var command = new UpdateCommerceCommand
            {
                State = new string('a', 51)
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Equal("State", command.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "State"));
        }

        [Fact]
        public void Should_be_invalid_when_city_is_empty()
        {
            var command = new UpdateCommerceCommand
            {
                City = ""
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Equal("City", command.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "City"));
        }

        [Fact]
        public void Should_be_invalid_when_city_is_null()
        {
            var command = new UpdateCommerceCommand
            {
                City = null
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Equal("City", command.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "City"));
        }

        [Fact]
        public void Should_be_invalid_when_city_does_not_has_min_length_3_chars()
        {
            var command = new UpdateCommerceCommand
            {
                City = "a"
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Equal("City", command.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "City"));
        }

        [Fact]
        public void Should_be_invalid_when_city_surpass_max_length_50_chars()
        {
            var command = new UpdateCommerceCommand
            {
                City = new string('a', 51)
            };

            command.Validate();

            Assert.True(command.Invalid);
            Assert.Equal("City", command.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "City"));
        }
    }
}
