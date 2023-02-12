
using Project.Core.Data;
using Project.Core.Entities;
using Project.Services.CustomQueryServices;
using Project.Services.ModalServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.AuthenticationManagment
{
    public interface IAuthenticationServices
    {
        Task<SaveStatusModel> LoginAsync(LoginModel request);

    }
}
