using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Services.ModalServices
{
    public class JwtSetting
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double AccessExpiration { get; set; }
    }
    public class KeySettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double AccessExpiration { get; set; }
    }
    public class SaveStatusModel
    {
        public SaveStatusModel()
        {
            Errors = new List<string>();
        }
        public SaveStatus Status { get; set; }
        public string Detail { get; set; }
        public string ARDetail { get; set; }
        public List<string> Errors { get; set; }
        public string Token { get; set; }
        public Guid? Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
        public string Otp { get; set; }
        public object Result { get; set; }
        public string userType { get; set; }
        public int AreaLocation1 { get; set; }
        public int? AreaLocation2 { get; set; }
        public int FailureCount { get; set; }
    }
    public class LogErrorModel
    {
        public string User { get; set; }
        public string Screen { get; set; }
        public string Action { get; set; }
        public string Status { get; set; }
        public string Msg { get; set; }

    }
    public enum SaveStatus
    {
        Failed = 0,
        Success = 1,
        Lockedout = 2,
        NotApproved = 3,
        DeActive = 4,
        ExpiredPassword = 5,
        FirstTime = 6,
        IsOnline = 7
    }
}
