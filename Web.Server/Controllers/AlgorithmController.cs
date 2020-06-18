using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Business.Logic;
using Business.Logic.Algorithms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Server.Responses;

namespace Web.Server.Controllers
{
    public abstract class AlgorithmController<OutputT> : ControllerBase
    {
        protected Algorithm<OutputT> _algorithm = null;

        protected AlgorithmController(Algorithm<OutputT> algorithm)
        {
            _algorithm = algorithm;
        }

        protected JsonResult RunAlgorithm(string b64Expression, Func<string, OutputT, string> prepareDetailsCallback = null)
        {
            try
            {
                string expression = null;
                try
                {
                    expression = Encoding.ASCII.GetString(Convert.FromBase64String(b64Expression));
                }
                catch (Exception ex)
                {
                    throw new Exception("Invalid expression!", ex);
                }

                OutputT output = _algorithm.Run(expression);
                if (prepareDetailsCallback != null)
                    return new RESTOk(prepareDetailsCallback(expression, output), output);
                else
                    return new RESTOk(output);
            }
            catch (Exception ex)
            {
                return new RESTError(ex);
            }
        }
    }
}
