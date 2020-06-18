using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Server.Responses
{
    public class RESTOk : RESTResponse
    {
        internal RESTOk(RESTResponse.Result result, string detail, object data)
            : base(result, detail, data)
        {

        }

        public RESTOk(string detail, object data) 
            : base(Result.Ok, detail, data)
        {

        }

        public RESTOk(object data)
            : base(Result.Ok, "", data)
        {

        }
    }
}
