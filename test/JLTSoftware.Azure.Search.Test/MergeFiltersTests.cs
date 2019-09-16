using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JLTSoftware.Azure.Search.Test
{
    [TestClass]
    public class MergeFiltersTests
    {
        [TestMethod]
        public void AllAssignedAnd()
        {
            string left = "field1 eq 'value1'";
            string right = "field2 eq 'value2'";
            string filter = left.MergeFilters(right);
            filter.Should().Be($"{left} and {right}");
        }

        [TestMethod]
        public void AllAssignedOr()
        {
            string left = "field1 eq 'value1'";
            string right = "field2 eq 'value2'";
            string filter = left.MergeFilters(right, "or");
            filter.Should().Be($"{left} or {right}");
        }

        [TestMethod]
        public void LeftNull()
        {
            string left = default;
            string right = "field eq 'value'";
            string filter = left.MergeFilters(right);
            filter.Should().Be(right);
        }

        [TestMethod]
        public void RightNull()
        {
            string left = "field eq 'value'";
            string right = default;
            string filter = left.MergeFilters(right);
            filter.Should().Be(left);
        }

        [TestMethod]
        public void BothNull()
        {
            string left = default;
            string right = default;
            string filter = left.MergeFilters(right);
            filter.Should().Be(default);
        }
    }
}