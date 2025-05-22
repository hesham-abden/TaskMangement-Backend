using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Features.User.Query.ListUser;

namespace TaskManagement.Application.Services
{
    public interface IUserService
    {
        public Task<List<ListUserVm>> GetAllUsersAsync();
    }
}
