using FluentAssertions;
using NUnit.Framework;

namespace JLTSoftware.Azure.Search.Test
{
    public class ValidateFilterTests
    {
        [Test]
        public void Simple()
        {
            string filter = "field eq 'value'";
            bool result = filter.ValidateFilter();
            result.Should().BeTrue();
        }

        [Test]
        public void Complex()
        {
            string filter = "(field1 eq 'value1') and (field2 eq 'value2')";
            bool result = filter.ValidateFilter();
            result.Should().BeTrue();
        }

        [Test]
        public void MissingLeading()
        {
            string filter = "field eq 'value')";
            bool result = filter.ValidateFilter();
            result.Should().BeFalse();
        }

        [Test]
        public void MissingTrailing()
        {
            string filter = "(field eq 'value'";
            bool result = filter.ValidateFilter();
            result.Should().BeFalse();
        }

        [Test]
        public void HackAttack()
        {
            string filter = ") or (field eq 'value') or (";
            bool result = filter.ValidateFilter();
            result.Should().BeFalse();
        }
    }
}
