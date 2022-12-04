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
        public async Task<HttpResponseData> GetUser([HttpTrigger(AuthorizationLevel.Function, "get", Route = "user/get")] HttpRequestData req)
        {
            //var myClientPrincipal = ClientPrincipalRetreiver.GetClientPrincipal(req);

            //var response = req.CreateResponse(HttpStatusCode.InternalServerError);

            //if (myClientPrincipal?.UserId is not null)
            //{
            try
            {
                var myClientPrincipal = ClientPrincipalRetreiver.GetClientPrincipal(req);
                var response = req.CreateResponse(HttpStatusCode.OK);
                //var req = await context.GetHttpRequestDataAsync() ?? throw new NotFoundException("Could not get request");

                if (req != null)
                {
                    var user = _mapper.Map<UserModel>(ClientPrincipalRetreiver.GetClientPrincipal(req));
                    await _userService.MakeSureUserExists(user);
                    await response.WriteAsJsonAsync(user);
                }

                return response;
                //var myClientPrincipal = ClientPrincipalRetreiver.GetClientPrincipal(req);
                //var response = req.CreateResponse(HttpStatusCode.OK);
                //response.WriteAsJsonAsync(myClientPrincipal);
                //return response;
            }
            catch (Exception ex)
            {
                var response = req.CreateResponse(HttpStatusCode.OK);
                await response.WriteAsJsonAsync(ex.Message);
                return response;
            }
        }
    }
}
