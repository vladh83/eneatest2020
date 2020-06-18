using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.Logic.Algorithms
{
    public class BalancedParantheses : Algorithm<bool>
    {
        private static string[] sOpenings = new string[]
        {
            "{",
            "(",
            "["
        };

        private static string[] sClosings = new string[]
        {
            "}",
            ")",
            "]"
        };

        private static Regex sRegex = null;

        protected override void OnValidate(string input)
        {
            if (sRegex == null)
            {
                List<string> all = new List<string>();
                all.AddRange(sOpenings);
                all.AddRange(sClosings);

                string regexStr = "^[";
                foreach (string str in all)
                    regexStr += "\\" + str;
                regexStr += "]+$";
                sRegex = new Regex(regexStr);
            }

            if (input == null)
                throw new Exception("Invalid input!");
            if (input.Length == 0)
                return;
            if (!sRegex.Match(input).Success)
                throw new Exception("Input contains invalid characters!");
        }

        protected override bool OnPerform(string input)
        {
            if (input.Length == 0)
                return false;

            for (int idx = 0; idx < input.Length; idx++)
            {
                string current = input[idx].ToString();
                if (sClosings.Contains(current))
                {
                    int openIdx = idx - 1;
                    if (openIdx < 0 || openIdx >= input.Length)
                        return false;

                    int closeIdx = idx;
                    string openSearch = sOpenings[Array.IndexOf(sClosings, current)];

                    if (input[openIdx].ToString() != openSearch)
                        return false;

                    input = input.Remove(closeIdx, 1);
                    input = input.Remove(openIdx, 1);
                    idx = openIdx - 1;
                }
            }

            return input.Length == 0;
        }
    }
}
