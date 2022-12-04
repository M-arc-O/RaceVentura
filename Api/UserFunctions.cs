using System.Net;
using Api.Authentication;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Api
{
    public class UserFunctions
    {
        [Function("GetUser")]
        public HttpResponseData GetUser([HttpTrigger(AuthorizationLevel.Function, "get", Route = "user/get")] HttpRequestData req)
        {
            var myClientPrincipal = ClientPrincipalRetreiver.GetClientPrincipal(req);

            var response = req.CreateResponse(HttpStatusCode.InternalServerError);

            if (myClientPrincipal?.UserId is not null)
            {
                response = req.CreateResponse(HttpStatusCode.OK);
                response.WriteAsJsonAsync(myClientPrincipal);
            }

            return response;
        }
    }
}
