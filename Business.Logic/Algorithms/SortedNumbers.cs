using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.Logic.Algorithms
{
    public class SortedNumbers : Algorithm<bool>
    {
        private static Regex sRegex = null;

        protected override void OnValidate(string input)
        {
            if (sRegex == null)
                sRegex = new Regex(@"^-?\d+(,\s*-?\d+)*$");

            if (input == null)
                throw new Exception("Invalid input!");
            if (input.Length == 0)
                return;
            if (!sRegex.Match(input).Success)
                throw new Exception("Invalid characters!");
        }

        protected override bool OnPerform(string input)
        {
            string[] tokens = input.Split(',');
            int? previousNr = null;
            bool? startedAscending = null;
            foreach (string token in tokens)
            {
                string nrStr = token.Trim();
                if (nrStr.Length == 0)
                    continue;

                int currentNr = int.Parse(nrStr);
                if (previousNr != null && startedAscending == null)
                    startedAscending = (currentNr >= previousNr);
                else if (previousNr != null && startedAscending != null)
                {
                    bool continuesAscending = (currentNr >= previousNr);
                    if (continuesAscending != startedAscending)
                        return false;
                }

                previousNr = currentNr;
            }
            if (previousNr == null)
                return false;

            return true;
        }
    }
}
