using System;
using System.ComponentModel;
using System.Reflection;

namespace Project.Services.Helper.Exceptions
{

    public enum ExceptionMessagesEnum
    {
        [Description("The User Not Found")]
        UserNotFound,

    }
    public static class Extensions
    {
        public static string ToDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }


}
