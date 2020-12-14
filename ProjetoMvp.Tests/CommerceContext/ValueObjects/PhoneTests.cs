using ProjetoMvp.CommerceContext.Domain.ValueObjects;
using System.Linq;
using Xunit;

namespace ProjetoMvp.Tests.CommerceContext.ValueObjects
{
    public class PhoneTests
    {
        private const string _valid_ddd = "061";
        private const string _valid_number = "99999999";
        private const string _valid_number2 = "999999999";

        [Fact]
        public void Should_validate_input_correctly_with_number_of_8_digits()
        {
            var phone = new Phone(_valid_ddd, _valid_number);
            Assert.True(phone.Valid);
        }

        [Fact]
        public void Should_validate_input_correctly_with_number_of_9_digits()
        {
            var phone = new Phone(_valid_ddd, _valid_number2);
            Assert.True(phone.Valid);
        }

        [Fact]
        public void Should_be_invalid_when_ddd_is_null()
        {
            var phone = new Phone(null, _valid_number);
            Assert.True(phone.Invalid);
            Assert.Equal("Phone.Ddd", phone.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "Phone.Ddd"));
        }

        [Fact]
        public void Should_be_invalid_when_number_is_null()
        {
            var phone = new Phone(_valid_ddd, null);
            Assert.True(phone.Invalid);
            Assert.Equal("Phone.Number", phone.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "Phone.Number"));
        }

        [Fact]
        public void Should_be_invalid_when_ddd_does_not_has_len_3_digits()
        {
            var phone = new Phone("12", _valid_number);
            Assert.True(phone.Invalid);
            Assert.Equal("Phone.Ddd", phone.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "Phone.Ddd"));
        }

        [Fact]
        public void Should_be_invalid_when_phone_has_less_than_8_digits()
        {
            var phone = new Phone(_valid_ddd, "9999999");
            Assert.True(phone.Invalid);
            Assert.Equal("Phone.Number", phone.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "Phone.Number"));
        }

        [Fact]
        public void Should_be_invalid_when_phone_surpass_max_len_of_9_digits()
        {
            var phone = new Phone(_valid_ddd, "9999999999");
            Assert.True(phone.Invalid);
            Assert.Equal("Phone.Number", phone.Notifications
                .Select(x => x.Property)
                .FirstOrDefault(x => x == "Phone.Number"));
        }
    }
}
