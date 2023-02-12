using Project.Services.ModalServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.AuthenticationManagment
{
    public interface IUserManager
    {
        Task<SaveStatusModel> IsValidUserAsync(string username, string password);
    }
}
