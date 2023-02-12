using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Services.Helper
{
    public class PasswordDates
    {
        public int Order
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public DateTime? Date
        {
            get;
            set;

        }

        public PasswordDates()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public PasswordDates(int order, string password, DateTime? date)
        {
            //
            // TODO: Add constructor logic here
            //
            this.Order = order;
            this.Password = password;
            this.Date = date;
        }
    }
}
