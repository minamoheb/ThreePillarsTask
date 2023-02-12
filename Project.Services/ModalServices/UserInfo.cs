using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Services.ModalServices
{
    public class UserInfo
    {

        public UserInfo()
        {
            UserName = ApplicationName = CompanyName = string.Empty;
            CustomerID = 0;
        }
        public string keyconnid { get; set; }
        public string AppName { get; set; }
        public string ChildUserName { get; set; }
        /// <summary>
        /// Comes from Gate Hashed QueryString
        /// </summary>
        public string UserName { get; set; }


        public string Email { get; set; }






        // public string CurrentPage;
        /// <summary>
        /// HttpContext.Current.Session["culture"] == "en-US" ? EnComanyName : ArComanyName
        /// get current company name depend on current culture
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// CustomerAccount.CUST_ID
        /// from gate
        /// </summary>
        public int CustomerID { get; set; }
        /// <summary>
        /// userdata.ApplicationName from Once Database
        /// CTRL table
        /// </summary>
        public string ApplicationName { get; set; }





        /// <summary>
        /// Fill with error list in login proccess
        /// </summary>
        public List<string> ErrorMessages { get; set; }

        /// <summary>
        /// CTRL.UserID
        /// </summary>
        public string ChildUserID { get; set; }





    }





    public enum LoginStatus
    {
        Success = 0,
        Failed = 1
    }
}
