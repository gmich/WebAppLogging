using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Infrastructure.Logging
{
    /// <summary>
    /// An attribute that catches all the Web API's uncaught exceptions in the controllers 
    /// </summary>
    /// <remarks>
    /// The ExceptionFilterAttribute can target both classes and methods.
    /// It can also be registered globally in config.Filters().
    /// Will be ignored if the ApiController action method throws a HttpResponseException.
    /// </remarks>
    /// <see cref="http://www.asp.net/web-api/overview/error-handling/exception-handling"/>
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {

            if (context.Exception is ApplicationSpecificException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Exception"
                });

            }
            
            //Log Critical errors
            Debug.WriteLine(context.Exception);

            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An error occurred, please try again or contact the administrator."),
                ReasonPhrase = "Critical Exception"
            });
        }
    }
}