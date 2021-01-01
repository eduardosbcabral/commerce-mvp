using ProjetoMvp.CommerceContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ProjetoMvp.Tests.Unit.CommerceContext.ValueObjects
{
    public class AgeTests
    {
        [Fact]
        public void Should_be_valid_when_age_is_eighteen()
        {
            var age = new Age(18);
            Assert.True(age.Valid);
        }

        [Fact]
        public void Should_be_valid_when_age_is_greater_than_eighteen()
        {
            var age = new Age(25);
            Assert.True(age.Valid);
        }

        [Fact]
        public void Should_be_invalid_when_age_is_lesser_than_eighteen()
        {
            var age = new Age(16);
            Assert.True(age.Invalid);
            Assert.Contains("Age.Value", age.Notifications
                .Select(x => x.Property));
        }
    }
}
