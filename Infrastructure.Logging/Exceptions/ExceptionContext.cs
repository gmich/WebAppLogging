using System;
using System.Net.Http;
using System.Web.Http.Controllers;

namespace Infrastructure.Logging
{
    public class ExceptionContext
    {
        public Exception Exception { get; set; }

        public HttpRequestMessage Request { get; set; }

        public HttpRequestContext RequestContext { get; set; }

        public HttpControllerContext ControllerContext { get; set; }

        public HttpActionContext ActionContext { get; set; }

        public HttpResponseMessage Response { get; set; }
    }
}
