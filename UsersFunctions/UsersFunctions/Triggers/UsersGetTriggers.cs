using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Linq;
using System.Threading.Tasks;
using UsersFunctions.Extensions;
using UsersFunctions.ViewModels.Requests;
using UsersFunctions.ViewModels.Responses;
using UsersService.Abstractions;

namespace UsersFunctions.Controllers
{
    public class UsersGetTriggers
    {
        private readonly IUsersService _usersService;
        public UsersGetTriggers(IUsersService usersService)
        {
            _usersService = usersService;
        }
        [FunctionName("GetUsersFunction")]
        public async Task<IActionResult> GetUser(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "users")] HttpRequest req)
        {
            var result = await _usersService.GetUsersAsync();

            var response = new GetUsersResponse
            {
                Users = result.Select(p => p.MapToUsersViewModel()).ToList()
            };
            return new OkObjectResult(response);
        }

        [FunctionName("CreateUserFunction")]
        public async Task<IActionResult> CreateUser(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "users")] CreateUserRequest request)
        {
            var user = request.User.MapToUser();
            await _usersService.AddUserAsync(user);
            return new CreatedResult($"/{user.DogeId}",user);
        }
    }
}
