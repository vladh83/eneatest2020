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
    public class SortedNumbersController : AlgorithmController<bool>
    {
        public SortedNumbersController(SortedNumbers sn) : base(sn)
        {

        }

        [HttpGet("{b64Expression}")]
        public JsonResult Get(string b64Expression)
        {
            return RunAlgorithm(b64Expression, ((Func<string, bool, string>)((string decodedExpression, bool sorted) =>
            {
                if (sorted)
                    return "True";
                else
                    return "False";
            })));
        }
    }
}
