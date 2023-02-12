using System;

namespace Project.Services.Helper.Exceptions
{
    public class CustomException:Exception
    {
  
        public CustomException(string message, int statusCode):base(message)
        {
            base.Data["StatusCode"] = statusCode;
        } 
        public CustomException(ExceptionMessagesEnum message, int statusCode):base(message.ToDescription())
        {
            base.Data["StatusCode"] = statusCode;
        } 
       
       
        
    }
}
