using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Services.AuthenticationManagment;
using Project.Services.ModalServices;
using Project.Services.Helper.Exceptions;

namespace ThreePillarsTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IAuthenticationServices _authService;
        public LoginController(IConfiguration config, IAuthenticationServices authService)
        {
            _config = config;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateTokenAsync(LoginModel login)
        {
            SaveStatusModel res = new SaveStatusModel();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IActionResult response = Unauthorized();
            try
            {
                res = await _authService.LoginAsync(login);
                if (res.Status == SaveStatus.Success)
                {
                    // get token after success
                    res.Result = new { login.username, res.Token };
                    return Ok(res);
                }
                else
                {
                    return BadRequest(res.Detail);
                }

            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message, BadRequest().StatusCode);
            }

        }


    }
}
