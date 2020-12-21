using ProjetoMvp.CommerceContext.Domain.ValueObjects;
using System;
using System.Linq;
using Xunit;

namespace ProjetoMvp.Tests.Unit.CommerceContext.ValueObjects
{
    public class AddressTests
    {
        private const string _valid_country = "Brasil";
        private const string _valid_state = "São Paulo";
        private const string _valid_city = "São Paulo";
        private const string _valid_zipcode = "11111111";
        private const string _valid_street = "street";

        [Fact]
        public void Should_validate_input_correctly()
        {
            var address = new Address(_valid_country, _valid_state, _valid_city, _valid_zipcode, _valid_street);
            Assert.True(address.Valid);
        }

        [Fact]
        public void Should_not_define_property_values_when_invalid()
        {
            var address = new Address(null, _valid_state, _valid_city, _valid_zipcode, _valid_street);
            Assert.Null(address.Country);
            Assert.Null(address.State);
            Assert.Null(address.City);
        }

        [Fact]
        public void Should_be_invalid_when_country_is_null()
        {
            var address = new Address(null, _valid_state, _valid_city, _valid_zipcode, _valid_street);
            Assert.True(address.Invalid);
            Assert.Equal("Country", address.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "Country"));
        }

        [Fact]
        public void Should_be_invalid_when_country_does_not_has_min_length_3_chars()
        {
            var invalid_country = "a";
            var address = new Address(invalid_country, _valid_state, _valid_city, _valid_zipcode, _valid_street);
            Assert.True(address.Invalid);
            Assert.Equal("Country", address.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "Country"));
        }

        [Fact]
        public void Should_be_invalid_when_country_surpass_max_length_50_chars()
        {
            var invalid_country = new string('a', 51);
            var address = new Address(invalid_country, _valid_state, _valid_city, _valid_zipcode, _valid_street);
            Assert.True(address.Invalid);
            Assert.Equal("Country", address.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "Country"));
        }

        [Fact]
        public void Should_be_invalid_when_state_is_null()
        {
            var address = new Address(_valid_country, null, _valid_city, _valid_zipcode, _valid_street);
            Assert.True(address.Invalid);
            Assert.Equal("State", address.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "State"));
        }

        [Fact]
        public void Should_be_invalid_when_state_does_not_has_min_length_3_chars()
        {
            var invalid_state = "a";
            var address = new Address(_valid_state, invalid_state, _valid_city, _valid_zipcode, _valid_street);
            Assert.True(address.Invalid);
            Assert.Equal("State", address.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "State"));
        }

        [Fact]
        public void Should_be_invalid_when_state_surpass_max_length_50_chars()
        {
            var invalid_state = new string('a', 51);
            var address = new Address(_valid_state, invalid_state, _valid_city, _valid_zipcode, _valid_street);
            Assert.True(address.Invalid);
            Assert.Equal("State", address.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "State"));
        }

        [Fact]
        public void Should_be_invalid_when_city_is_null()
        {
            var address = new Address(_valid_country, _valid_state, null, _valid_zipcode, _valid_street);
            Assert.True(address.Invalid);
            Assert.Equal("City", address.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "City"));
        }

        [Fact]
        public void Should_be_invalid_when_city_does_not_has_min_length_3_chars()
        {
            var invalid_city = "a";
            var address = new Address(_valid_state, _valid_city, invalid_city, _valid_zipcode, _valid_street);
            Assert.True(address.Invalid);
            Assert.Equal("City", address.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "City"));
        }

        [Fact]
        public void Should_be_invalid_when_city_surpass_max_length_50_chars()
        {
            var invalid_city = new string('a', 51);
            var address = new Address(_valid_state, _valid_city, invalid_city, _valid_zipcode, _valid_street);
            Assert.True(address.Invalid);
            Assert.Equal("City", address.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "City"));
        }
    }
}
