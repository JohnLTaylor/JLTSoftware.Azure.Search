using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JLTSoftware.Azure.Search.Test
{
    [TestClass]
    public class ValidateFilterTests
    {
        [TestMethod]
        public void Empty()
        {
            string filter = default;
            bool result = filter.ValidateFilter();
            result.Should().BeTrue();
        }

        [TestMethod]
        public void Simple()
        {
            string filter = "field eq 'value'";
            bool result = filter.ValidateFilter();
            result.Should().BeTrue();
        }

        [TestMethod]
        public void Complex()
        {
            string filter = "(field1 eq 'value1') and (field2 eq 'value2')";
            bool result = filter.ValidateFilter();
            result.Should().BeTrue();
        }

        [TestMethod]
        public void MissingLeading()
        {
            string filter = "field eq 'value')";
            bool result = filter.ValidateFilter();
            result.Should().BeFalse();
        }

        [TestMethod]
        public void MissingTrailing()
        {
            string filter = "(field eq 'value'";
            bool result = filter.ValidateFilter();
            result.Should().BeFalse();
        }

        [TestMethod]
        public void HackAttack()
        {
            string filter = ") or (field eq 'value') or (";
            bool result = filter.ValidateFilter();
            result.Should().BeFalse();
        }
    }
}
