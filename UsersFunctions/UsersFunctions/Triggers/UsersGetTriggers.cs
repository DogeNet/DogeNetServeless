using AutoMapper;
using DogeNet.NetworkingTools.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using UsersFunctions.Commands.Abstractions;
using UsersFunctions.ViewModels;

namespace UsersFunctions.Controllers
{
    public class UsersGetTriggers
    {
        private readonly IGetUsersCommand _getUsersCommand;
        private readonly ISerializer _serializer;
        private readonly IMapper _mapper;
        public UsersGetTriggers(IGetUsersCommand getUsersCommand, ISerializer serializer, IMapper mapper)
        {
            _getUsersCommand = getUsersCommand;
            _serializer = serializer;
            _mapper = mapper;
        }
        [FunctionName("GetUsersFunction")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "users")] HttpRequest req,
            ILogger log)
        {
            var Response = _getUsersCommand.GetUsers();
            var ViewModelResponse = _mapper.Map<UsersViewModel>(Response);
            return new OkObjectResult(ViewModelResponse);
        }
    }
}
