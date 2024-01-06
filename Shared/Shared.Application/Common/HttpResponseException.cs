using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Application.Common
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(HttpStatusCode statusCode, object? value = null) =>
            (StatusCode, Value) = (statusCode, value);

        public HttpStatusCode StatusCode { get; }
        public object? Value { get; }
    }
}
