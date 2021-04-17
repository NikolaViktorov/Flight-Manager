using Project_Flight_Manager.ViewModels.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Flight_Manager.Services.Contracts
{
    public interface IAdministrationService
    {
        public Task<List<UserViewModel>> GetUsers(int count, string filter, string curId);
        public Task DeleteUser(string id);
    }
}
