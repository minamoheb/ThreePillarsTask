using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Services.ModalServices
{

    public class LoginModel
    {
        public string userid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string details { get; set; }
        public string token { get; set; }


    }


}
