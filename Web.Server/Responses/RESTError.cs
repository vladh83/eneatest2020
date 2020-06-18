using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Server.Responses
{
    public class RESTError : RESTResponse
    {
        internal RESTError(RESTResponse.Result result, string detail, object data)
            : base(result, detail, data)
        {

        }

        public RESTError(string detail, object data)
            : base(Result.Error, detail, data)
        {

        }

        public RESTError(Exception ex)
            : base(Result.Error, ex.Message, ex.ToString())
        {

        }
    }
}
