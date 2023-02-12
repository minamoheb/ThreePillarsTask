using Project.Services.AuthenticationManagment;
using Project.Services.ModalServices;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Project.Core.Entities;

namespace Project.Services.AuthenticationManagment
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IUserManager _IUserManager;
        private readonly JwtSetting _jwtSetting;

        public AuthenticationServices(IUserManager service, JwtSetting jwtSetting)
        {
            _IUserManager = service;
            _jwtSetting = jwtSetting;

        }

        public async Task<SaveStatusModel> LoginAsync(LoginModel request)
        {
            //var token = string.Empty;
            var res = await _IUserManager.IsValidUserAsync(request.username, request.password);

            if (res.Status == SaveStatus.Success)
            {
                if (res.Result != null)
                {
                    request.username = ((ApplicationUser)res.Result).UserName;
                }
                //Create new claim with related user data company name, copmany ID .etc
                var key = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Secret));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var jwtToken = new JwtSecurityToken(
                    _jwtSetting.Issuer,
                    _jwtSetting.Audience,
                     GetClaims(request),
                   // expires: DateTime.Now.AddMinutes(_jwtSetting.AccessExpiration),
                   expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials
                );
                res.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                return res;
            }
            else
            {
                //Failed
                //Lockedout
            }
            return res;
        }


        private Claim[] GetClaims(LoginModel user)
        {
            var claim = new[]
            {
                new Claim(nameof(user.username), user.username)

            };
            return claim;
        }


    }
}
