using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiAndMvc5.Controllers
{
    public class WebapitestController : ApiController
    {
        private readonly IRepo repo;

        public WebapitestController(IRepo repo)
        {
            this.repo = repo;            
        }

        [HttpGet, Route("IsServiceUp")]
        public HttpResponseMessage IsServiceUp()
        {
            return new HttpResponseMessage
            {
                Content = new StringContent("Web Service is Up and Running! Machine Name: " + Environment.MachineName + " - " + repo.Name),
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
