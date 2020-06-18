using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Server.Responses
{
    public abstract class RESTResponse
    {
        public enum Result
        {
            Ok = 0,
            Error = 1
        };

        protected readonly List<object> _innerFormat = null;

        internal RESTResponse(Result result, string detail, object data)
        {
            _innerFormat = new List<object>();
            _innerFormat.Add(result);
            _innerFormat.Add(detail);
            _innerFormat.Add(data);
        }

        public Result result
        {
            get
            {
                return (Result)_innerFormat[0];
            }
        }

        public string detail
        {
            get
            {
                return (string)_innerFormat[1];
            }
        }

        public object data
        {
            get
            {
                return _innerFormat[2];
            }
        }

        public static implicit operator JsonResult(RESTResponse r)
        {
            return new JsonResult(r._innerFormat, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            });
        }
    }
}
