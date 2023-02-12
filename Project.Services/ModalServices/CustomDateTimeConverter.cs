using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Services.ModalServices
{
    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            base.DateTimeFormat = "dd/MM/yyyy";
        }
    }
}
