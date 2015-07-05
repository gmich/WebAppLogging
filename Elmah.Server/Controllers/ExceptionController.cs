using NLog;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Elmah.Server.Controllers
{
    public class ExceptionController : ApiController
    {
        private readonly static Logger logger = LogManager.GetCurrentClassLogger();

        // GET /action
        [Route("action")]
        public void GetActionException()
        {
            throw new InvalidOperationException("This exception was thrown in an action method.");
        }

        // GET /nlogException
        [Route("nlogException")]
        public void GetnlogException()
        {
            try
            {
                throw new Exception("This is logged with NLog ");
            }
            catch (Exception ex)
            {
                logger.Error(ex, " {0} ", ex.Message);
            }
        }

        // GET /elmahProgrammatically
        [Route("elmahProgrammatically")]
        public void GetLogToELMAHProgrammatically()
        {
            try
            {
                throw new Exception("This is logged with Elmah programmatically");
            }
            catch (Exception ex)
            {
                //ErrorSignal.FromCurrentContext().Raise(ex);
                ErrorLog.GetDefault(null).Log(new Error(ex));
            }
        }

        // GET /content
        [Route("content")]
        public IHttpActionResult GetContentWriteException()
        {
            return ResponseMessage(new HttpResponseMessage
                {
                    RequestMessage = Request,
                    Content = new ThrowingHttpContent()
                });
        }

        private class ThrowingHttpContent : HttpContent
        {
            protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
            {
                throw new InvalidOperationException("This exception was thrown while writing content.");
            }

            protected override bool TryComputeLength(out long length)
            {
                length = 0;
                return false;
            }
        }
    }
}