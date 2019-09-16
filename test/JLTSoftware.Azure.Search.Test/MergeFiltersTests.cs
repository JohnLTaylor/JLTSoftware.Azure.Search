using FluentAssertions;
using NUnit.Framework;

namespace JLTSoftware.Azure.Search.Test
{
    public class MergeFiltersTests
    {
        [Test]
        public void AllAssignedAnd()
        {
            string left = "field1 eq 'value1'";
            string right = "field2 eq 'value2'";
            string filter = left.MergeFilters(right);
            filter.Should().Be($"{left} and {right}");
        }

        [Test]
        public void AllAssignedOr()
        {
            string left = "field1 eq 'value1'";
            string right = "field2 eq 'value2'";
            string filter = left.MergeFilters(right, "or");
            filter.Should().Be($"{left} or {right}");
        }

        [Test]
        public void LeftNull()
        {
            string left = default;
            string right = "field eq 'value'";
            string filter = left.MergeFilters(right);
            filter.Should().Be(right);
        }

        [Test]
        public void RightNull()
        {
            string left = "field eq 'value'";
            string right = default;
            string filter = left.MergeFilters(right);
            filter.Should().Be(left);
        }

        [Test]
        public void BothNull()
        {
            string left = default;
            string right = default;
            string filter = left.MergeFilters(right);
            filter.Should().Be(default);
        }
    }
}