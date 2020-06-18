using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Logic.Algorithms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Server.Responses;

namespace Web.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LongestPrefixSuffixController : AlgorithmController<int>
    {
        public LongestPrefixSuffixController(LongestPrefixSuffix lps) : base(lps)
        {

        }

        [HttpGet]
        [HttpGet("{b64Expression}")]
        public JsonResult Get(string b64Expression)
        {
            return RunAlgorithm(b64Expression, ((Func<string, int, string>)((string decodedExpression, int longestPrefixSuffix) =>
            {
                if (longestPrefixSuffix > 0)
                    return longestPrefixSuffix.ToString() + " - " + decodedExpression.Substring(0, longestPrefixSuffix);
                else
                    return "0";
            })));
        }
    }
}
