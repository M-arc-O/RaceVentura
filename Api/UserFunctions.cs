using System.Net;
using Api.Authentication;
using AutoMapper;
using Azure;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using RaceVenturaWebApp.Business.Models;
using RaceVenturaWebApp.Business.Services;

namespace Api
{
    public class UserFunctions
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserFunctions(ILoggerFactory loggerFactory, IMapper mapper, IUserService userService)
        {
            _logger = loggerFactory.CreateLogger<UserFunctions>();
            _mapper = mapper;
            _userService = userService;
        }

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
