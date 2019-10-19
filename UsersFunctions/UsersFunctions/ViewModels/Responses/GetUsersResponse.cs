using System.Collections.Generic;
using UsersFunctions.ViewModels.Data;

namespace UsersFunctions.ViewModels.Responses
{
    public class GetUsersResponse
    {
        public List<UsersViewModel> Users { get; set; }
    }
}
