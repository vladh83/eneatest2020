using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Logic.Algorithms
{
    public class LongestPrefixSuffix : Algorithm<int>
    {
        protected override void OnValidate(string input)
        {
            if (input == null)
                throw new Exception("Invalid input!");
        }

        protected override int OnPerform(string input)
        {
            int halfIdx = Convert.ToInt32(Math.Floor(Convert.ToDouble(input.Length) / 2.0));
            for (int leftIdx = halfIdx; leftIdx >= 0 && leftIdx < input.Length; leftIdx--)
            {
                int rightIdx = input.Length - 1 - leftIdx;
                if (leftIdx >= rightIdx || rightIdx < 0)
                    continue;

                string prefix = input.Substring(0, leftIdx + 1);
                if (input.EndsWith(prefix))
                    return prefix.Length;
            }

            return 0;
        }
    }
}
