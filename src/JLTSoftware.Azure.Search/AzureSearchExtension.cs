namespace JLTSoftware.Azure.Search
{
    public static class AzureSearchExtension
    {
        public static string MergeFilters(this string left, string right, string mergeOperator = "and")
        {
            if (string.IsNullOrWhiteSpace(left))
            {
                return right;
            }

            if (string.IsNullOrWhiteSpace(right))
            {
                return left;
            }

            return $"{left} {mergeOperator} {right}";
        }

        public static bool ValidateFilter(this string value)
        {
            int parentheses = 0;

            foreach (var ch in value)
            {
                switch (ch)
                {
                    case '(':
                        parentheses++;
                        break;

                    case ')':
                        if (--parentheses < 0)
                        {
                            return false;
                        }
                        break;
                }
            }

            return parentheses == 0;
        }
    }
}
