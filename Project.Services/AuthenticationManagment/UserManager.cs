using Project.Core.Data;
using Project.Core.Entities;
using Project.Services.ModalServices;
using AutoMapper;
using RepositoryLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;


namespace Project.Services.AuthenticationManagment
{
    public class UserManager : IUserManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<SystemDBContext> _uow;

        public UserManager(IUnitOfWork<SystemDBContext> uow, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _uow = uow;
        }




        public async Task<SaveStatusModel> IsValidUserAsync(string username, string password)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    return new SaveStatusModel
                    {
                        Status = SaveStatus.Failed,
                        Detail = "No username or password found!!",
                        Errors = new List<string>() { "No username or password found!!" }
                    };
                }
                //var user = new CustomUser() {UserName = username };
                var user = await _userManager.FindByNameAsync(username);
                if (user == null)
                {
                    return new SaveStatusModel
                    {
                        Status = SaveStatus.Failed,
                        Detail = "User Not Found!!",
                        Errors = new List<string>() { "User Not Found!!" }
                    };
                }



                var isValidPassword = await _userManager.CheckPasswordAsync(user, password);
                if (isValidPassword)
                {
                    return new SaveStatusModel
                    {
                        Status = SaveStatus.Success,
                        Detail = "Success",
                        Result = user
                    };

                }
          
                else
                {
                    int accessFailedCount = await _userManager.GetAccessFailedCountAsync(user);

                    return new SaveStatusModel
                    {
                        Status = SaveStatus.Failed,
                        Detail = "Incorrect Password. You Have Only " + (5 - accessFailedCount) + " Attempts",
                        Errors = new List<string>() { "Incorrect Password. You Have Only " + (5 - accessFailedCount) + " Attempts" },
                        FailureCount = accessFailedCount
                    };

                }


            }
            catch (Exception ex)
            {
                return new SaveStatusModel
                {
                    Status = SaveStatus.Failed,
                    Detail = ex.Message,
                    Errors = new List<string>() { ex.Message }
                };
            }
        }

    }
}
